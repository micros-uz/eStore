using eStore.Interfaces.Repositories;
using eStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        private IDBContextFactory _factory;
        private bool _disposed = false;

        public EfUnitOfWork(IDBContextFactory factory)
        {
            _factory = factory;
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
                return _context ?? (_context = _factory.Get());
            }
        }

        #region IUnitOfWork

        IGenericRepository<Genre> IUnitOfWork.GenreRepository
        {
            get { return _genreRpstr ?? (_genreRpstr = new EfGenericRepository<Genre>(Context.Genres)); }
        }

        IGenericRepository<Author> IUnitOfWork.AuthorRepository
        {
            get { return _authorRpstr ?? (_authorRpstr = new EfGenericRepository<Author>(Context.Authors)); }
        }

        IGenericRepository<Book> IUnitOfWork.BooksRepository
        {
            get
            {
                return _bookRpstr ?? (_bookRpstr = new EfGenericRepository<Book>(Context.Books));
            }
        }

        IGenericRepository<User> IUnitOfWork.UserRepository
        {
            get
            {
                return _userRpstr ?? (_userRpstr = new EfGenericRepository<User>(Context.Users));
            }
        }

        IGenericRepository<Role> IUnitOfWork.RoleRepository
        {
            get
            {
                return _roleRpstr ?? (_roleRpstr = new EfGenericRepository<Role>(Context.Roles));
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        #endregion
    }
}
