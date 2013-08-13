using eStore.Core.Services;
using eStore.DataAccess;
using eStore.Interfaces.IoC;
using eStore.Interfaces.Services;

namespace eStore.Core
{
    public static class ServicesBootstraper
    {
        public static void Init(IIoC ioc)
        {
            DataAccessBootstrapper.Init(ioc);

            ioc.Register<IStoreService, StoreService>();
            ioc.Register<IAuthenticationService, AuthenticationService>();
            ioc.Register<IUserService, UserService>();
        }
    }
}
