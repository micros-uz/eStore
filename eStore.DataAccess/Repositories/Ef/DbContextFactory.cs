using System.Data.Entity.Infrastructure;
using eStore.Interfaces.Repositories;
using eStore.DataAccess.Repositories.Ef.BoundedContexts;
using eStore.Domain.Security;

namespace eStore.DataAccess.Repositories.Ef
{
    internal class DbContextFactory : IDbContextFactory
    {
        private CatalogContext _context;
        private readonly IConnectionStringProvider _connStrProvider;

        internal DbContextFactory(IConnectionStringProvider connStrProvider)
        {
            _connStrProvider = connStrProvider;
        }

        #region IDbContextFactory<EStoreDbContext> Members

        IBaseContext IDbContextFactory.GetContext<T>()
        {
            if (typeof(T) == typeof(User) ||
                typeof(T) == typeof(Role))
                return new SecurityContext(_connStrProvider.ConnectionString);
            else 
                return new CatalogContext(_connStrProvider.ConnectionString);
        }

        #endregion
    }
}
