using Blog.Data.Models;
using Blog.DataAccess.SqlServer;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data.Repositories.Keywords
{
    public class KeywordRepository : SqlServerEntityFrameworkCrudRepository<Keyword, BlogContext>, IKeywordRepository
    {
        public KeywordRepository(BlogContext context) : base(context)
        {
        }

        protected override DbSet<Keyword> EntityDbSet => this.Context.Keywords;
    }
}
