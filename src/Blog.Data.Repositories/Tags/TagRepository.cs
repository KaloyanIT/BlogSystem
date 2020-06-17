namespace Blog.Data.Repositories.Tags
{
    using DataAccess.SqlServer;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using Models.Context;

    public class TagRepository : SqlServerEntityFrameworkCrudRepository<Tag, BlogContext>, ITagRepository
    {
        public TagRepository(BlogContext context) : base(context)
        {
        }

        protected override DbSet<Tag> EntityDbSet => this.Context.Tags;
    }
}
