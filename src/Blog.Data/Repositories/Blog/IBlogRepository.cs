namespace Blog.Data.Repositories.Blog
{
    using System.Threading.Tasks;

    using Models;
    using DataAccess;

    public interface IBlogRepository : IRepository<BlogPost>
    {
        Task<BlogPost> GetByTitle(string title);
    }
}
