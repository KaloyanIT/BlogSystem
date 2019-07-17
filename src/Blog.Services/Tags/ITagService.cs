using Blog.Data.Models;
using Blog.Services.Contracts.Base;
using Blog.Services.Tags.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Services.Tags
{
    public interface ITagService
    {
        Task Save(TagServiceModel value);

        IQueryable<Tag> GetAll();

        Task<Tag> GetById(Guid? id);

        Task DeleteById(Guid? id);
    }
}
