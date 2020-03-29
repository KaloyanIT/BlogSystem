
namespace Blog.Data.Repositories.BlogPostTags
{
    using Models;
    using DataAccess.SqlServer;
    using Microsoft.EntityFrameworkCore;

    public class BlogPostTagRepository : SqlServerEntityFrameworkCrudRepository<BlogPostTag, BlogContext>, IBlogPostTagRepository
    {
        public BlogPostTagRepository(BlogContext context) : base(context)
        {
        }

        protected override DbSet<BlogPostTag> EntityDbSet => Context.BlogPostTags;
    }
}
