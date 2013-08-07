using eStore.Interfaces.Repositories;
using System.Linq;
using System.Linq.Expressions;

namespace eStore.DataAccess
{
    public class SimpleDbContext : IDbContext
    {
        #region IDbContext 

        public IQueryable<TEntity> All<TEntity>(params Expression<System.Func<TEntity, object>>[] includeProperties) where TEntity : class
        {
            throw new System.NotImplementedException();
        }

        public TEntity Find<TEntity>(int id) where TEntity : class
        {
            throw new System.NotImplementedException();
        }

        public TEntity Create<TEntity>() where TEntity : class
        {
            throw new System.NotImplementedException();
        }

        public void Insert<TEntity>(TEntity entity) where TEntity : class
        {
            throw new System.NotImplementedException();
        }

        public void Update<TEntity>(TEntity entity) where TEntity : class
        {
            throw new System.NotImplementedException();
        }

        public void Delete<TEntity>(int id) where TEntity : class
        {
            throw new System.NotImplementedException();
        }

        public int SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
