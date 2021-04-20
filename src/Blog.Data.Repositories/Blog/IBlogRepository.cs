namespace Blog.Data.Repositories.Blog
{
    using System.Threading.Tasks;
    using Base;
    using DataAccess;
    using Models;

    public interface IBlogRepository : IRepository<BlogPost>, ITransientRepository
    {
        Task<BlogPost> GetByTitle(string title);

        Task<BlogPost> GetBySlug(string slug);
    }
}
