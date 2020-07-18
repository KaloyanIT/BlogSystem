namespace Blog.Data.Repositories.Meta.OpenGraphs
{
    using DataAccess.SqlServer;
    using Microsoft.EntityFrameworkCore;
    using Models.Context;
    using Models.Meta;

    public class OpenGraphRepository : SqlServerEntityFrameworkCrudRepository<OpenGraph, BlogContext>, IOpenGraphRepository
    {
        public OpenGraphRepository(BlogContext context) : base(context)
        {
        }

        protected override DbSet<OpenGraph> EntityDbSet => EntityDbSet;
    }
}
