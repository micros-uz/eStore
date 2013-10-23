using eStore.Interfaces.Repositories;
using eStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.Infrastructure;
using eStore.DataAccess.Repositories.Ef.BoundedContexts;

namespace eStore.DataAccess.Repositories.Ef
{
    internal class EfUnitOfWork : IUnitOfWork
    {
        private IBaseContext _context;
        private IDbContextFactory _contextFactory;
        private IRepositoryFactory _repoFactory;
        private bool _disposed = false;

        public EfUnitOfWork(IDbContextFactory factory, IRepositoryFactory repoFactory)
        {
            _contextFactory = factory;
            _repoFactory = repoFactory;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_context != null)
                    {
                        ((BaseContext)_context).Dispose();
                    }
                }
            }

            _disposed = true;
        }

        private IBaseContext GetContext<T>() where T : class
        {
            return _context ?? (_context = _contextFactory.GetContext<T>());
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #region IUnitOfWork

        IGenericRepository<T> IUnitOfWork.GetRepository<T>()
        {
            return _repoFactory.GetRepository<T>(GetContext<T>());
        }

        public void Save()
        {
            if (_context != null)
            {
                ((BaseContext)_context).SaveChanges();
            }
        }

        #endregion
    }
}
