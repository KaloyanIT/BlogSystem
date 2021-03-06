﻿namespace Blog.Controllers.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using AutoMapper;
    using Blog.Infrastructure.Options;
    using Data.Base;
    using Data.Models;
    using Data.Models.Context;
    using EmailService.Adapters;
    using Identity;
    using Infrastructure;
    using Infrastructure.AutoMapper;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc.Razor;
    using Microsoft.AspNetCore.Routing;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Services.Base;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection InjectIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IBlogContext, BlogContext>();
            services.AddDbContext<BlogContext>(options =>
                options.UseSqlServer(configuration.GetDefaultConnectionString(), x => x.MigrationsAssembly("Blog.Data")));

            services.AddIdentity<User, Role>()
              .AddEntityFrameworkStores<BlogContext>()
              .AddDefaultTokenProviders()
              .AddTokenProvider<EmailConfirmationTokenProvider<User>>("emailconfirmation")
              .AddPasswordValidator<CustomPasswordValidator<User>>();

            services.Configure<IdentityOptions>(opt =>
            {
                opt.Password.RequiredLength = 6;
                opt.Password.RequireDigit = false;
                opt.Password.RequireUppercase = false;
                opt.User.RequireUniqueEmail = true;

                opt.SignIn.RequireConfirmedEmail = false;
                opt.Tokens.EmailConfirmationTokenProvider = "emailconfirmation";

                opt.Lockout.AllowedForNewUsers = true;
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);
                opt.Lockout.MaxFailedAccessAttempts = 3;
            });

            services.Configure<DataProtectionTokenProviderOptions>(opt =>
                        opt.TokenLifespan = TimeSpan.FromHours(2));

            services.Configure<EmailConfirmationTokenProviderOptions>(opt =>
                opt.TokenLifespan = TimeSpan.FromDays(3));

            return services;
        }

        public static IServiceCollection InjectAutoMapper(this IServiceCollection services)
        {
            AutoMapperConfig.Init();

            services.AddSingleton(typeof(IMapper), AutoMapperConfig.MapperConfiguration!.CreateMapper());

            return services;
        }

        public static IServiceCollection InjectStandardServices(this IServiceCollection services)
        {
            var serviceType = typeof(IService);
            var singletonServiceType = typeof(ISingletonService);
            var scopedServiceType = typeof(IScopedService);

            var assemblyNames = new List<string>() { "Blog.Services", "Blog.EmailService" };

            AppDomain.CurrentDomain.Load(assemblyNames[0]);
            AppDomain.CurrentDomain.Load(assemblyNames[1]);

            var types = AssemblyHelper
                .GetAllBlogServiceAssemblies()
                .SelectMany(x => x.GetExportedTypes())
                .Where(t => t.IsClass && !t.IsAbstract)
                .Select(t => new
                {
                    Service = t.GetInterface($"I{t.Name}"),
                    Implementation = t

                })
                .Where(t => t.Service != null);

            foreach (var type in types)
            {
                if (serviceType.IsAssignableFrom(type.Service))
                {
                    services.AddTransient(type.Service, type.Implementation);
                }
                else if (scopedServiceType.IsAssignableFrom(type.Service))
                {
                    services.AddScoped(type.Service, type.Implementation);
                }
                else if (singletonServiceType.IsAssignableFrom(type.Service))
                {
                    services.AddSingleton(type.Service, type.Implementation);
                }

            }

            services.AddTransient<BaseEmailMessageAdapter, BaseEmailMessageAdapter>();

            return services;
        }

        public static IServiceCollection InjectRepositories(this IServiceCollection services)
        {
            var repositoryType = typeof(ITransientRepository);

            var assemblyRepositoriesName = "Blog.Data.Repositories";

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            var assembly = assemblies.SingleOrDefault(x => x.GetName().Name == assemblyRepositoriesName);

            if (assembly == null)
            {
                assembly = Assembly.Load(assemblyRepositoriesName);
            }

            var types = assembly
                .GetExportedTypes()
                .Where(t => t.IsClass && !t.IsAbstract)
                .Select(t => new
                {
                    Repository = t.GetInterface($"I{t.Name}"),
                    Implementation = t
                })
                .Where(t => t.Repository != null);

            foreach (var type in types)
            {
                if (repositoryType.IsAssignableFrom(type.Repository))
                {
                    services.AddTransient(type.Repository, type.Implementation);
                }
            }

            return services;
        }

        public static IServiceCollection AddMvcConfigurations(this IServiceCollection services)
        {
            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.AreaViewLocationFormats.Clear();
                options.AreaViewLocationFormats.Add("{2}/Views/{1}/{0}.cshtml");
                options.AreaViewLocationFormats.Add("/{2}/Views/Shared/{0}.cshtml");
                options.AreaViewLocationFormats.Add("/Shared/{0}.cshtml");
            });

            services.AddMvc();
            services.AddRouting();

            services.Configure<RouteOptions>(options =>
            {
                options.LowercaseUrls = true;
            });

            return services;
        }

        public static IServiceCollection InjectConfigurationOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<GoogleAnalyticsOptions>(options => configuration.GetSection("GoogleAnalytics").Bind(options));
            services.Configure<GoogleRecaptchaOptions>(options => configuration.GetSection("GoogleRecaptcha").Bind(options));
            services.Configure<SendGridOptions>(options => configuration.GetSection("SendGrid").Bind(options));
            services.Configure<SystemOptions>(options => configuration.GetSection("System").Bind(options));

            return services;
        }

        public static IServiceCollection AddCokkiesPolicy(this IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            return services;
        }
    }
}
