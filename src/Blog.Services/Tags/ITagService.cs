
namespace Blog.Services.Tags
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Data.Models;
    using Base;
    using Tags.Models;

    public interface ITagService : IService
    {
        Task Save(TagServiceModel value);

        IQueryable<Tag> GetAll();

        Task<Tag> GetById(Guid? id);

        Task DeleteById(Guid? id);
    }
}
