using eStore.Interfaces.Repositories;
using eStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eStore.DataAccess.Repositories
{
    internal class EfUnitOfWork : IUnitOfWork
    {
        private IGenericRepository<Genre> _genreRpstr;
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

        public void Save()
        {
            _context.SaveChanges();
        }

        #endregion
    }
}
