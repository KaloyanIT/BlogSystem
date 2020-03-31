namespace Blog.Data.Repositories.Blog
{
    using System.Threading.Tasks;

    using Models;
    using DataAccess;
    using Base;
    using System.Collections.Generic;

    public interface IBlogRepository : IRepository<BlogPost>, ITransientRepository
    {
        Task<BlogPost> GetByTitle(string title);
    }
}
