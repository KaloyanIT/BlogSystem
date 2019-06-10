using Blog.Data.Models;
using Blog.DataAccess;
using System.Threading.Tasks;

namespace Blog.Data.Repositories.Blog
{
    public interface IBlogRepository : IRepository<BlogPost>
    {
        Task<BlogPost> GetByTitle(string title);
    }
}
