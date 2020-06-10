namespace Blog.Data.Repositories.BlogPostKeywords
{
    using Models;
    using DataAccess.SqlServer;
    using Models.Context;
    using Microsoft.EntityFrameworkCore;

    public class BlogPostKeywordRepository : SqlServerEntityFrameworkCrudRepository<BlogPostKeyword, BlogContext>, IBlogPostKeywordRepository
    {
        public BlogPostKeywordRepository(BlogContext context) : base(context)
        {
        }

        protected override DbSet<BlogPostKeyword> EntityDbSet => Context.BlogPostKeywords;
    }
}
