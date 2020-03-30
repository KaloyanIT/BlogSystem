﻿namespace Blog.Controllers.Helpers
{
    using AutoMapper;
    using Data;
    using Data.Repositories.Blog;
    using Data.Repositories.BlogPostKeywords;
    using Data.Repositories.BlogPostTags;
    using Data.Repositories.Comments;
    using Data.Repositories.Keywords;
    using Data.Repositories.Tags;
    using Infrastructure.AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Services.Blog;
    using Services.Tags;
    using Services.User;

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
            services.AddTransient<ITagRepository, TagRepository>();
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

        //public static IServiceCollection InjectRepositories(this IServiceCollection services)
        //{
        //    services.AddTransient<IBlogRepository, BlogRepository>();
        //    services.AddTransient<ICommentRepository, CommentRepository>();
        //    services.AddTransient<IBlogPostKeywordRepository, BlogPostKeywordRepository>();
        //    services.AddTransient<IBlogPostTagRepository, BlogPostTagRepository>();
        //    services.AddTransient<ITagSqlRepository, TagRepository>();
        //    services.AddTransient<IKeywordRepository, KeywordRepository>();

        //    return services;
        //}        
    }
}
