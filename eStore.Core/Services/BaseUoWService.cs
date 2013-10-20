using eStore.Interfaces.Repositories;
using System;
using System.Security.Cryptography;

namespace eStore.Core.Services
{
    internal class BaseUoWService 
    {
        private readonly IUnitOfWork _uow;
        private bool _disposed = false;

        internal BaseUoWService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        protected IUnitOfWork UoW
        {
            get
            {
                return _uow;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _uow.Dispose();
                }
            }
            
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
