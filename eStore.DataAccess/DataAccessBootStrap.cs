using eStore.DataAccess.Repositories;
using eStore.DataAccess.Repositories.Ef;
using eStore.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eStore.DataAccess
{
    public static class DataAccessBootStrap
    {
        public static void Init(Interfaces.IoC.IIoC ioc)
        {
            ioc.Register<IUnitOfWork, EfUnitOfWork>();
            ioc.Register<IDBContextFactory, DbContextFactory>();
        }
    }
}
