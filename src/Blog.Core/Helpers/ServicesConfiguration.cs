using Blog.Data;
using Blog.Data.Models;
using Blog.Data.Repositories.Blog;
using Blog.Data.Repositories.Comments;
using Blog.DataAccess;
using Blog.Services;
using Blog.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Core.Helpers
{
    public static class ServicesConfiguration
    {
        public static void AddBlogServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IBlogContext, BlogContext>();
            services.AddDbContext<BlogContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<IBlogService, BlogService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IBlogRepository, BlogRepository>();
            services.AddTransient<ICommentRepository, CommentRepository>();
        }
    }
}
