namespace Blog.Data.Repositories.BlogPostKeywords
{
    using Base;
    using DataAccess;
    using Models;

    public interface IBlogPostKeywordRepository : IRepository<BlogPostKeyword>, ITransientRepository
    {
    }
}
