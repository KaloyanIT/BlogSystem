using Blog.Data.Models;
namespace Blog.Data.Repositories.BlogPostKeywords
{
    using DataAccess;
    using Base;

    public interface IBlogPostKeywordRepository : IRepository<BlogPostKeyword>, ITransientRepository
    {
    }
}
