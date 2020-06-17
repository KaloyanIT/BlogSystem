namespace Blog.Data.Repositories.BlogPostTags
{
    using DataAccess;
    using Base;
    using Models;

    public interface IBlogPostTagRepository : IRepository<BlogPostTag>, ITransientRepository
    {
    }
}
