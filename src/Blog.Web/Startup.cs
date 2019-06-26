using AutoMapper;
using Blog.Core.Helpers;
using Blog.Data;
using Blog.Data.Seeders;
using Blog.Infrastructure.AutoMapper;
using Blog.Services;
using Blog.Services.Contracts;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Blog
{
    public class Startup
    {
        private readonly IHostingEnvironment environment;
        private readonly IConfiguration configuration;

        public IHostingEnvironment Environment => this.environment;

        public IConfiguration Configuration => this.configuration;

        public Startup(IHostingEnvironment environment, IConfiguration configuration)
        {
            this.environment = environment;
            this.configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            AutoMapperConfig.Init();
            services.AddBlogServices(this.configuration);


            services.AddIdentity<IdentityUser, IdentityRole>()
              .AddEntityFrameworkStores<BlogContext>()
              .AddDefaultTokenProviders();


            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.AreaViewLocationFormats.Clear();
                options.AreaViewLocationFormats.Add("{2}/Views/{1}/{0}.cshtml");
                options.AreaViewLocationFormats.Add("/{2}/Views/Shared/{0}.cshtml");
                options.AreaViewLocationFormats.Add("/Shared/{0}.cshtml");
            });

            services.AddMvc();

            services.Configure<RouteOptions>(options =>
            {
                options.LowercaseUrls = true;
            });

            services.Configure<IdentityOptions>(options =>
            {              
                options.SignIn.RequireConfirmedEmail = false;
            });

            //services.AddAuthentication().AddApplicationCookie();

            services.AddSession(opt =>
            {
                opt.IdleTimeout = TimeSpan.FromMinutes(5);
                opt.Cookie.HttpOnly = true;
            });


            services.ConfigureApplicationCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromHours(4);            
            });


            services.AddRouting();


            var protectionBuilder = services.AddDataProtection().SetApplicationName("BLOG_IT")
.SetDefaultKeyLifetime(TimeSpan.FromDays(90));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                //app.UseWebpackDevMiddleware();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }
            UpdateDatabase(app);
            MainSeeder.Seed(serviceProvider, this.Configuration).Wait();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseSession();
            

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areaRoute",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            app.UseMvcWithDefaultRoute();
        }

        private static void UpdateDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<BlogContext>())
                {
                    //context.Database.EnsureCreated();
                    context.Database.Migrate();
                }

              
            }
        }
    }
}
