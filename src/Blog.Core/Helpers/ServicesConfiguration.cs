using AutoMapper;
using Blog.Data;
using Blog.Data.Repositories.Blog;
using Blog.Data.Repositories.BlogPostKeywords;
using Blog.Data.Repositories.BlogPostTags;
using Blog.Data.Repositories.Comments;
using Blog.Data.Repositories.Keywords;
using Blog.Data.Repositories.Tags;
using Blog.Infrastructure.AutoMapper;
using Blog.Services;
using Blog.Services.Contracts;
using Blog.Services.Tags;
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
            services.AddTransient<IBlogPostKeywordRepository, BlogPostKeywordRepository>();
            services.AddTransient<IBlogPostTagRepository, BlogPostTagRepository>();
            services.AddTransient<ITagSqlRepository, TagRepository>();
            services.AddTransient<IKeywordRepository, KeywordRepository>();
            services.AddSingleton(typeof(IMapper), AutoMapperConfig.MapperConfiguration.CreateMapper());
        }

        public static IServiceCollection InjectCore(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IBlogContext, BlogContext>();
            services.AddDbContext<BlogContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddSingleton(typeof(IMapper), AutoMapperConfig.MapperConfiguration.CreateMapper());

            return services;
        }

        public static IServiceCollection InjectRepositories(this IServiceCollection services)
        {
            services.AddTransient<IBlogRepository, BlogRepository>();
            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<IBlogPostKeywordRepository, BlogPostKeywordRepository>();
            services.AddTransient<IBlogPostTagRepository, BlogPostTagRepository>();
            services.AddTransient<ITagSqlRepository, TagRepository>();
            services.AddTransient<IKeywordRepository, KeywordRepository>();

            return services;
        }

        public static IServiceCollection InjectServices(this IServiceCollection services)
        {
            services.AddTransient<IBlogService, BlogService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ITagService, TagService>();

            return services;
        }
    }
}
