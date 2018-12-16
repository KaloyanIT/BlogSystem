using Blog.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Services.Contracts
{
    public interface IBlogService
    {
        Task Create(BlogServiceModel blogServiceModel);

        Task<BlogServiceModel> Edit(BlogServiceModel blogServiceModel);

        Task<ICollection<BlogServiceModel>> GetAll();

        Task<BlogServiceModel> GetById();
    }
}
