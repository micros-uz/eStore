using eStore.DataAccess.Repositories;
using eStore.DataAccess.Repositories.Ef;
using eStore.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WrapIoC;
using System.Data.Entity.Infrastructure;

namespace eStore.DataAccess
{
    public static class DataAccessBootstrapper
    {
        public static void Init(IIoC ioc)
        {
            ioc.Register<IUnitOfWork, EfUnitOfWork>();
            ioc.Register<IDbContextFactory<EStoreDbContext>, DbContextFactory>();

            OrmInitializer.Init();
        }
    }
}
