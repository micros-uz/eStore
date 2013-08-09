using eStore.DataAccess;
using eStore.Interfaces.IoC;
using eStore.Interfaces.Services;

namespace eStore.Services
{
    public static class ServicesBootstrap
    {
        public static void Init(IIoC ioc)
        {
            DataAccessBootStrap.Init(ioc);

            ioc.Register<IStoreService, StoreService>();
        }
    }
}
