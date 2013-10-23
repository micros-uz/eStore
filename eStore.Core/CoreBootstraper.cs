using eStore.Core.Services;
using eStore.DataAccess;
using eStore.Interfaces;
using eStore.Interfaces.Repositories;
using eStore.Interfaces.Services;

//[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(eStore.Core.CoreBootstraper), "Init")]

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
            WrapIoC.IoC.Current.Register<IIdentityService, IdentityService>();
            WrapIoC.IoC.Current.Register<IForumService, ForumService>();
        }

        public static void NotifyDbMigrated()
        {
            if (WrapIoC.IoC.Current.Get<IDbVersionProvider>().GetVersion() >= 2)
            {
                WrapIoC.IoC.Current.Get<ISeedActionProvider>().Action();
            }
        }
    }
}
