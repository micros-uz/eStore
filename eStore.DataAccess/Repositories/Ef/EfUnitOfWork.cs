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
        private IGenericRepository<Book> _bookRpstr;
        private EStoreDbContext _context;
        private IDBContextFactory _factory;

        public EfUnitOfWork(IDBContextFactory factory)
        {
            _factory = factory;
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

        IGenericRepository<Book> IUnitOfWork.BooksRepository
        {
            get
            {
                return _bookRpstr ?? (_bookRpstr = new EfGenericRepository<Book>(Context.Books));
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        #endregion
    }
}
