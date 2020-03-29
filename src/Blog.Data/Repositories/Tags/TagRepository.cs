using Blog.Data.Models;
namespace Blog.Data.Repositories.Tags
{
    using DataAccess.SqlServer;
    using Microsoft.EntityFrameworkCore;

    public class TagRepository : SqlServerEntityFrameworkCrudRepository<Tag, BlogContext>, ITagSqlRepository
    {
        public TagRepository(BlogContext context) : base(context)
        {
        }

        protected override DbSet<Tag> EntityDbSet => this.Context.Tags;
    }
}
