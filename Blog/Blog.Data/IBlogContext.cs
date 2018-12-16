using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.Data
{
    public interface IBlogContext
    {
        Task<EntityEntry<TEntity>> AddAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default(CancellationToken)) where TEntity : class;

        Task AddRangeAsync(IEnumerable<object> entities, CancellationToken cancellationToken = default(CancellationToken));

        Task AddRangeAsync(params object[] entities);

        void Dispose();

        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        Task<TEntity> FindAsync<TEntity>(params object[] keyValues) where TEntity : class;

        Task<object> FindAsync(Type entityType, object[] keyValues, CancellationToken cancellationToken);

        Task<TEntity> FindAsync<TEntity>(object[] keyValues, CancellationToken cancellationToken) where TEntity : class;

        Task<object> FindAsync(Type entityType, params object[] keyValues);

        DbQuery<TQuery> Query<TQuery>() where TQuery : class;

        EntityEntry Remove(object entity);

        EntityEntry<TEntity> Remove<TEntity>(TEntity entity) where TEntity : class;

        void RemoveRange(IEnumerable<object> entities);

        void RemoveRange(params object[] entities);

        int SaveChanges();

        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken));

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        EntityEntry<TEntity> Update<TEntity>(TEntity entity) where TEntity : class;

        void UpdateRange(IEnumerable<object> entities);
    }
}
