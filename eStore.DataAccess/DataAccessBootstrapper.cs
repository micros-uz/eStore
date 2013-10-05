using System.Data.Entity.Infrastructure;
using eStore.DataAccess.Repositories.Ef;
using eStore.Interfaces.Repositories;
using WrapIoC;
using eStore.Interfaces;

namespace eStore.DataAccess
{
    public static class DataAccessBootstrapper
    {
        public static void Init(IIoC ioc)
        {
            ioc.Register<IConnectionStringProvider, ConnectionStringProvider>();
            ioc.Register<IUnitOfWork, EfUnitOfWork>();
            ioc.Register<IDbContextFactory, DbContextFactory>();
            ioc.Register<IRepositoryFactory, RepositoryFactory>();
            ioc.Register<IDbVersionProvider, DbVersionProvider>();

            OrmInitializer.Init();
        }
    }
}
