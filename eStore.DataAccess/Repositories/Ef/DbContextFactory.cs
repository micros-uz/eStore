using System.Data.Entity.Infrastructure;
using eStore.Interfaces.Repositories;
using eStore.DataAccess.Repositories.Ef.BoundedContexts;
using eStore.Domain.Security;
using eStore.Domain.Forum;

namespace eStore.DataAccess.Repositories.Ef
{
    internal class DbContextFactory : IDbContextFactory
    {
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
            else if (typeof(T) == typeof(TopicCategory)||
                typeof(T) == typeof(Topic)||
                typeof(T) == typeof(Post))
                return new ForumContext(_connStrProvider.ConnectionString);
            else
                return new CatalogContext(_connStrProvider.ConnectionString);
        }

        #endregion
    }
}
