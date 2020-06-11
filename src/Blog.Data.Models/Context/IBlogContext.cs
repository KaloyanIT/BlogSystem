namespace Blog.Data.Models.Context
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;

    public interface IBlogContext
    {
        ValueTask<EntityEntry<TEntity>> AddAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default(CancellationToken)) where TEntity : class;

        Task AddRangeAsync(IEnumerable<object> entities, CancellationToken cancellationToken = default(CancellationToken));

        Task AddRangeAsync(params object[] entities);

        void Dispose();

        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        ValueTask<TEntity> FindAsync<TEntity>(params object[] keyValues) where TEntity : class;

        ValueTask<object> FindAsync(Type entityType, object[] keyValues, CancellationToken cancellationToken);

        ValueTask<TEntity> FindAsync<TEntity>(object[] keyValues, CancellationToken cancellationToken) where TEntity : class;

        ValueTask<object> FindAsync(Type entityType, params object[] keyValues);

        EntityEntry Remove(object entity);

        EntityEntry<TEntity> Remove<TEntity>(TEntity entity) where TEntity : class;

        void RemoveRange(IEnumerable<object> entities);

        void RemoveRange(params object[] entities);

        int SaveChanges();

        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken));

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));

#pragma warning disable CA1716 // Identifiers should not match keywords
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
#pragma warning restore CA1716 // Identifiers should not match keywords

        EntityEntry<TEntity> Update<TEntity>(TEntity entity) where TEntity : class;

        void UpdateRange(IEnumerable<object> entities);
    }
}
