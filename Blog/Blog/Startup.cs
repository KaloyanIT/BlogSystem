using AutoMapper;
using Blog.Data;
using Blog.Services;
using Blog.Services.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
            services.AddScoped<IBlogContext, BlogContext>();
            services.AddDbContext<BlogContext>(options => options.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection")));


            services.AddIdentity<IdentityUser, IdentityRole>()
              .AddEntityFrameworkStores<BlogContext>()
              .AddDefaultTokenProviders();

            services.AddTransient<IBlogService, BlogService>();

            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.AreaViewLocationFormats.Clear();
                options.AreaViewLocationFormats.Add("{2}/Views/{1}/{0}.cshtml");
                options.AreaViewLocationFormats.Add("/{2}/Views/Shared/{0}.cshtml");
                options.AreaViewLocationFormats.Add("/Shared/{0}.cshtml");
            });

            services.AddMvc();
            services.AddRouting();
            services.AddAutoMapper();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }
            UpdateDatabase(app);
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areaRoute",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            app.UseAuthentication();
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
