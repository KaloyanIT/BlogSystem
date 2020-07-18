namespace Blog.Data.Repositories.Meta.OpenGraphs
{
    using System;
    using System.Threading.Tasks;
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

        public async Task<OpenGraph?> GetByAttachedItemId(Guid attachedItemId)
        {
            var openGraph = await EntityDbSet.FindAsync(new { attachedItemId = attachedItemId});

            return openGraph;
        }
    }
}
