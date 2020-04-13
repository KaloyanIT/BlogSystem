namespace Blog
{
    using System;
    using Blog.Infrastructure.Emails;
    using Controllers.Helpers;
    using Infrastructure.AutoMapper;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.DataProtection;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public class Startup
    {
        private readonly IWebHostEnvironment _environment;
        private readonly IConfiguration _configuration;

        public Startup(IWebHostEnvironment environment, IConfiguration configuration)
        {
            _environment = environment;
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            AutoMapperConfig.Init();

            services.InjectIdentity(_configuration)
                .InjectRepositories()
                .InjectStandartServices();

            services.AddSingleton(_configuration.GetEmailConfiguration());
            services.AddTransient<IEmailSender, EmailSender>();


            services.AddMvcConfigurations();

            services.AddSession(opt =>
            {
                opt.IdleTimeout = TimeSpan.FromMinutes(5);
                opt.Cookie.HttpOnly = true;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromHours(4);
            });


            var protectionBuilder = services.AddDataProtection().SetApplicationName("BLOG_IT")
                    .SetDefaultKeyLifetime(TimeSpan.FromDays(90));
        }


        public void Configure(IApplicationBuilder app, IServiceProvider serviceProvider)
        {
            app.UseDeveloperExceptionPage();

            app.SetUpDatabase(_configuration);

            app.UseStaticFiles();

            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            app.RegisterRoutes();
        }
    }
}
