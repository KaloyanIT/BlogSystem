namespace Blog.Web
{
    using System;
    using System.IO;
    using Blog.Controllers.ViewComponents;
    using Blog.EmailService;
    using Controllers.Helpers;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.DataProtection;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Razor.TagHelpers;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.FileProviders;

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
            services.InjectIdentity(_configuration)
                .InjectRepositories()
                .InjectStandardServices()
                .InjectConfigurationOptions(_configuration)
                .AddCokkiesPolicy();



            services.AddTransient<ITagHelperComponent, GoogleAnalyticsTagHelperComponent>();
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
                options.LoginPath = "/login";
                options.AccessDeniedPath = "/error";
                options.SlidingExpiration = true;
            });


            var protectionBuilder = services.AddDataProtection().SetApplicationName("BLOG_IT")
                    .SetDefaultKeyLifetime(TimeSpan.FromDays(90));

            services.InjectAutoMapper();
        }


        public void Configure(IApplicationBuilder app)
        {
            app.UseApplicationExceptionPage(_environment);

            app.SetUpDatabase(_configuration);

            app.UseStaticFiles();

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                Path.Combine(_environment.ContentRootPath, "StaticFiles")),
                RequestPath = "/StaticFiles"
            });

            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            app.RegisterRoutes();
        }
    }
}
