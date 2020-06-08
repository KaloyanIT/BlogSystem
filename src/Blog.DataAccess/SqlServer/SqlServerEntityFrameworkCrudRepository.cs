using Microsoft.EntityFrameworkCore;
using System;
namespace Blog.DataAccess.SqlServer
{
    using System.Linq;
    using System.Threading.Tasks;
    using Blog.Data.Base;

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
                throw new ArgumentNullException("Delete entity is null");
            }

            var entry = this.Context.Entry(deleteThis);

            if (entry.State == EntityState.Detached)
            {
                this.EntityDbSet.Attach(deleteThis);
            }

            this.EntityDbSet.Remove(deleteThis);

            await this.Context.SaveChangesAsync();
        }

        public IQueryable<TEntity> GetAll()
        {
            return this.EntityDbSet;
        }

        public async Task<TEntity> GetById(Guid id)
        {
            return await this.EntityDbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Save(TEntity saveThis)
        {
            if (saveThis == null)
            {
                throw new ArgumentNullException("Save entity is null");
            }

            await this.VerifyItemIsAddedOrAttachedToDbSet(this.EntityDbSet, saveThis);

            await this.Context.SaveChangesAsync();
        }
    }
}
