using System;
using System.Linq;
using System.Linq.Expressions;

namespace eStore.Interfaces.Repositories
{
    public interface IDbContext : IDisposable
    {
        IQueryable<TEntity> All<TEntity>(params Expression<Func<TEntity, object>>[] includeProperties) where TEntity : class;//, IEntity<TId>;

        TEntity Find<TEntity>(int id) where TEntity : class;//, IEntity<TId>;

        TEntity Create<TEntity>() where TEntity : class;//, IEntity<TId>;

        void Insert<TEntity>(TEntity entity) where TEntity : class;//, IEntity<TId>;

        void Update<TEntity>(TEntity entity) where TEntity : class;//, IEntity<TId>;

        void Delete<TEntity>(int id) where TEntity : class;//, IEntity<TId>;

        int SaveChanges();
    }
}
