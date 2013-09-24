using System.Data.Entity.Infrastructure;
using eStore.Interfaces.Repositories;

namespace eStore.DataAccess.Repositories.Ef
{
    internal class DbContextFactory : IDbContextFactory<EStoreDbContext>
    {
        private EStoreDbContext _context;
        private readonly IConnectionStringProvider _connStrProvider;

        internal DbContextFactory(IConnectionStringProvider connStrProvider)
        {
            _connStrProvider = connStrProvider;
        }

        #region IDbContextFactory<EStoreDbContext> Members

        EStoreDbContext IDbContextFactory<EStoreDbContext>.Create()
        {
            return _context ?? (_context = new EStoreDbContext(_connStrProvider.ConnectionString));
            //return new EStoreDbContext(ConnectionStringFactory.ConnectionString);
        }

        #endregion
    }
}
