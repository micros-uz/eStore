using eStore.Core.Services;
using eStore.DataAccess;
using eStore.Interfaces.Services;
using WrapIoC;

namespace eStore.Core
{
    public static class ServicesBootstraper
    {
        public static void Init()
        {
            WrapIoC.IoC.Init(new eStore.Core.IoC.NinjectIoC());
            DataAccessBootstrapper.Init(WrapIoC.IoC.Current);

            WrapIoC.IoC.Current.Register<IStoreService, StoreService>();
            WrapIoC.IoC.Current.Register<IAuthenticationService, AuthenticationService>();
            WrapIoC.IoC.Current.Register<IUserService, UserService>();
        }
    }
}
