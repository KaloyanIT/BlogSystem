namespace Blog.Data.Repositories.Keywords
{
    using Models;
    using DataAccess.SqlServer;
    using Microsoft.EntityFrameworkCore;

    public class KeywordRepository : SqlServerEntityFrameworkCrudRepository<Keyword, BlogContext>, IKeywordRepository
    {
        public KeywordRepository(BlogContext context) : base(context)
        {
        }

        protected override DbSet<Keyword> EntityDbSet => this.Context.Keywords;
    }
}
