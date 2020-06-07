namespace Blog.Controllers.Helpers
{
    using System.Linq;
    using AutoMapper;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc.Razor;
    using Microsoft.AspNetCore.Routing;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using Data;
    using Data.Base;
    using Infrastructure.AutoMapper;
    using Services.Base;
    using Blog.Data.Models;
    using System;
    using Blog.Controllers.Identity;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection InjectIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IBlogContext, BlogContext>();
            services.AddDbContext<BlogContext>(options => options.UseSqlServer(configuration.GetDefaultConnectionString()));

            services.AddIdentity<User, IdentityRole>()
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

            services.AddSingleton(typeof(IMapper), AutoMapperConfig.MapperConfiguration!.CreateMapper());

            return services;
        }

        public static IServiceCollection InjectStandartServices(this IServiceCollection services)
        {
            var serviceType = typeof(IService);
            var singletonServiceType = typeof(ISingletonService);
            var scopedServiceType = typeof(IScopedService);

            var types = serviceType
                .Assembly
                .GetExportedTypes()
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
                else if (scopedServiceType.IsAssignableFrom(type.Service))
                {
                    services.AddSingleton(type.Service, type.Implementation);
                }

            }

            return services;
        }

        public static IServiceCollection InjectRepositories(this IServiceCollection services)
        {
            var repositoryType = typeof(ITransientRepository);

            var types = repositoryType
                .Assembly
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
    }
}
