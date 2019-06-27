using System;
using System.Linq;
using System.Threading.Tasks;
using Blog.Data.Models;
using Blog.Services.Models;

namespace Blog.Services.Contracts
{
    public interface IBlogService
    {
        Task Create(CreateBlogServiceModel blogServiceModel);

        Task<BlogServiceModel> Edit(BlogServiceModel blogServiceModel);

        IQueryable<BlogPost> GetAll();

        IQueryable<BlogPost> GetAllLatest();

        Task<BlogPost> GetById(Guid? id);

        Task<bool> Exists(Guid? id);
    }
}
