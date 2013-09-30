using eStore.Interfaces.Repositories;
using eStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.Infrastructure;

namespace eStore.DataAccess.Repositories.Ef
{
    internal class EfUnitOfWork : IUnitOfWork
    {
        private IGenericRepository<Genre> _genreRpstr;
        private IGenericRepository<Author> _authorRpstr;
        private IGenericRepository<Book> _bookRpstr;
        private IGenericRepository<User> _userRpstr;
        private IGenericRepository<Role> _roleRpstr;
        private EStoreDbContext _context;
        private IDbContextFactory<EStoreDbContext> _factory;
        private IRepositoryFactory _repoFactory;
        private bool _disposed = false;

        public EfUnitOfWork(IDbContextFactory<EStoreDbContext> factory, IRepositoryFactory repoFactory)
        {
            _factory = factory;
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
                        _context.Dispose();
                    }
                }
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private EStoreDbContext Context
        {
            get
            {
                return _context ?? (_context = _factory.Create());
            }
        }

        #region IUnitOfWork

        IGenericRepository<Genre> IUnitOfWork.GenreRepository
        {
            get { return _genreRpstr ?? (_genreRpstr = _repoFactory.GetRepository<Genre>(Context)); }
        }

        IGenericRepository<Author> IUnitOfWork.AuthorRepository
        {
            get { return _authorRpstr ?? (_authorRpstr = _repoFactory.GetRepository<Author>(Context)); }
        }

        IGenericRepository<Book> IUnitOfWork.BooksRepository
        {
            get
            {
                return _bookRpstr ?? (_bookRpstr = _repoFactory.GetRepository<Book>(Context));
            }
        }

        IGenericRepository<User> IUnitOfWork.UserRepository
        {
            get
            {
                return _userRpstr ?? (_userRpstr = _repoFactory.GetRepository<User>(Context));
            }
        }

        IGenericRepository<Role> IUnitOfWork.RoleRepository
        {
            get
            {
                return _roleRpstr ?? (_roleRpstr = _repoFactory.GetRepository<Role>(Context));
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        #endregion
    }
}
