using Blog.Data.Models;
using Blog.DataAccess.SqlServer;
namespace Blog.Data.Repositories.BlogPostKeywords
{
    using Microsoft.EntityFrameworkCore;

    public class BlogPostKeywordRepository : SqlServerEntityFrameworkCrudRepository<BlogPostKeyword, BlogContext>, IBlogPostKeywordRepository
    {
        public BlogPostKeywordRepository(BlogContext context) : base(context)
        {
        }

        protected override DbSet<BlogPostKeyword> EntityDbSet => Context.BlogPostKeywords;
    }
}
