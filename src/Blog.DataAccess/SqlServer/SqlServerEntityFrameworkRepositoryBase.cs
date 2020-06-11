namespace Blog.DataAccess.SqlServer
{
    using System;
    using System.Threading.Tasks;
    using Blog.Data.Base;
    using Microsoft.EntityFrameworkCore;

    public abstract class SqlServerEntityFrameworkRepositoryBase<TEntity, TDbContext> : IDisposable
        where TEntity : class, IDbObject
        where TDbContext : DbContext
    {
        private readonly TDbContext _context;

        public SqlServerEntityFrameworkRepositoryBase(TDbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context), "Missing context.");
            }

            _context = context;
        }

        protected TDbContext Context
        {
            get
            {
                return _context;
            }
        }

        public void Dispose()
        {
            ((IDisposable)Context).Dispose();
            GC.SuppressFinalize(this);
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
                    var entry = Context.Entry<TEntity>(item);

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
