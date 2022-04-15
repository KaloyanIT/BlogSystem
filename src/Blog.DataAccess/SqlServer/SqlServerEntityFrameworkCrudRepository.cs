namespace Blog.DataAccess.SqlServer
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Data.Base.Contracts;
    using Microsoft.EntityFrameworkCore;

    public abstract class SqlServerEntityFrameworkCrudRepository<TEntity, TDbContext> :
        SqlServerEntityFrameworkRepositoryBase<TEntity, TDbContext>, IRepository<TEntity>
        where TEntity : class, IDbObject
        where TDbContext : DbContext
    {
        public SqlServerEntityFrameworkCrudRepository(TDbContext context) : base(context)
        {

        }

        protected abstract DbSet<TEntity> EntityDbSet
        {
            get;
        }

        public async Task Delete(TEntity deleteThis)
        {
            if (deleteThis == null)
            {
                throw new ArgumentNullException(nameof(deleteThis), "Delete entity is null");
            }

            var entry = Context.Entry(deleteThis);

            if (entry.State == EntityState.Detached)
            {
                EntityDbSet.Attach(deleteThis);
            }

            EntityDbSet.Remove(deleteThis);

            await Context.SaveChangesAsync();
        }

        public IQueryable<TEntity> GetAll()
        {
            return EntityDbSet;
        }

        public async Task<TEntity> GetById(Guid id)
        {
#pragma warning disable CS8603
            return await EntityDbSet.FirstOrDefaultAsync(x => x.Id == id);
#pragma warning restore CS8603
        }

        public async Task Save(TEntity saveThis)
        {
            if (saveThis == null)
            {
                throw new ArgumentNullException(nameof(saveThis), "Save entity is null");
            }

            await VerifyItemIsAddedOrAttachedToDbSet(EntityDbSet, saveThis);

            await Context.SaveChangesAsync();
        }
    }
}
