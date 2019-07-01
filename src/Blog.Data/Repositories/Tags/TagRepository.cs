using Blog.Data.Models;
using Blog.DataAccess.SqlServer;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data.Repositories.Tags
{
    public class TagRepository : SqlServerEntityFrameworkCrudRepository<Tag, BlogContext>, ITagSqlRepository
    {
        public TagRepository(BlogContext context) : base(context)
        {
        }

        protected override DbSet<Tag> EntityDbSet => this.Context.Tags;
    }
}
