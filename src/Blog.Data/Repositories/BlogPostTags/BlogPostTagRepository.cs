using Blog.Data.Models;
using Blog.DataAccess.SqlServer;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data.Repositories.BlogPostTags
{
    public class BlogPostTagRepository : SqlServerEntityFrameworkCrudRepository<BlogPostTag, BlogContext>, IBlogPostTagRepository
    {
        public BlogPostTagRepository(BlogContext context) : base(context)
        {
        }

        protected override DbSet<BlogPostTag> EntityDbSet => this.Context.BlogPostTags;
    }
}
