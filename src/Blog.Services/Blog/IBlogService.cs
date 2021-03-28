namespace Blog.Services.Blog
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Data.Models;
    using Base;
    using Models;

    public interface IBlogService : IService
    {
        Task<BlogPost> Create(CreateBlogServiceModel blogServiceModel);

        Task<BlogServiceModel> Edit(BlogServiceModel blogServiceModel);

        IQueryable<BlogPost> GetAll();
        
        IQueryable<BlogPost> GetAll(bool showOnHomepage);
        
        IQueryable<BlogPost> GetAll(bool showOnHomepage, string tag);

        IQueryable<BlogPost> GetAllLatest();

        Task<BlogPost?> GetById(Guid? id);

        Task<bool> Exists(Guid? id);

        Task Delete(Guid? id);
    }
}
