using eStore.Core.Services;
using eStore.DataAccess;
using eStore.Interfaces.Services;

[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(eStore.Core.CoreBootstraper), "Init")]

namespace eStore.Core
{
    public static class CoreBootstraper
    {
        public static void Init()
        {
            WrapIoC.IoC.Init(new eStore.Core.IoC.NinjectIoC());
            DataAccessBootstrapper.Init(WrapIoC.IoC.Current);

            WrapIoC.IoC.Current.Register<IAdminService, AdminService>();
            WrapIoC.IoC.Current.Register<IStoreService, StoreService>();
            WrapIoC.IoC.Current.Register<IAuthenticationService, AuthenticationService>();
            WrapIoC.IoC.Current.Register<IUserService, UserService>();
            WrapIoC.IoC.Current.Register<ICartService, CartService>();
        }
    }
}
