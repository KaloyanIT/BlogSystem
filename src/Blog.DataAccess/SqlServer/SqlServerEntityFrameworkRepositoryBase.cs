using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Blog.DataAccess.SqlServer
{
    public abstract class SqlServerEntityFrameworkRepositoryBase<TEntity, TDbContext> : IDisposable
        where TEntity : class, IDbObject
        where TDbContext : DbContext
    {
        private readonly TDbContext context;

        public SqlServerEntityFrameworkRepositoryBase(TDbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("Missing context.");
            }

            this.context = context;
        }

        protected TDbContext Context
        {
            get
            {
                return this.context;
            }
        }

        public void Dispose()
        {
            ((IDisposable)this.Context).Dispose();
        }

        protected async Task VerifyItemIsAddedOrAttachedToDbSet(DbSet<TEntity> dbset, TEntity item)
        {
            if (item == null)
            {
                return;
            }
            else
            {
                if (!await dbset.AnyAsync(x => x.Id == item.Id))
                {
                    dbset.Add(item);
                }
                else
                {
                    var entry = this.Context.Entry<TEntity>(item);

                    if (entry.State == EntityState.Detached)
                    {
                        dbset.Attach(item);
                    }

                    entry.State = EntityState.Modified;
                }
            }
        }
    }
}
