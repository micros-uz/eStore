using System.Data.Entity.Infrastructure;
using eStore.DataAccess.Repositories.Ef;
using eStore.Interfaces.Repositories;
using WrapIoC;

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

            OrmInitializer.Init();
        }
    }
}
