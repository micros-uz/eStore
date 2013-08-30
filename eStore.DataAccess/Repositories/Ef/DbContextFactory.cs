using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace eStore.DataAccess.Repositories.Ef
{
    internal class DbContextFactory : IDBContextFactory
    {
        private EStoreDbContext _context;

        #region IDBContextFactory 

        EStoreDbContext IDBContextFactory.Get()
        {
            return _context ?? (_context = new EStoreDbContext(ConnectionStringFactory.ConnectionString));
        }

        #endregion
    }
}
