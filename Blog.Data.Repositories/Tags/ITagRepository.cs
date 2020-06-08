using Blog.Data.Models;
namespace Blog.Data.Repositories.Tags
{
    using DataAccess;
    using Base;

    public interface ITagRepository : IRepository<Tag>, ITransientRepository
    {
    }
}
