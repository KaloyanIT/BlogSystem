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

        protected override DbSet<OpenGraph> EntityDbSet => Context.OpenGraphs;

        public async Task<OpenGraph?> GetByAttachedItemId(Guid attachedItemId)
        {
            var openGraph = await EntityDbSet.FirstOrDefaultAsync(x => x.AttachedItemId == attachedItemId);

            return openGraph;
        }
    }
}
