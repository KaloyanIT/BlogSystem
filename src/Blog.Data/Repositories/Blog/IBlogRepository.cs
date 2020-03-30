namespace Blog.Data.Repositories.Blog
{
    using System.Threading.Tasks;

    using Models;
    using DataAccess;
    using Base;

    public interface IBlogRepository : IRepository<BlogPost>, ITransientRepository
    {
        Task<BlogPost> GetByTitle(string title);
    }
}
