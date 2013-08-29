using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using eStore.Core;
using eStore.Logic;
using eStore.Web.Infrastructure;
using eStore.Web.UI.Areas.Account.Controllers;
using eStore.Web.UI.Areas.Admin.Controllers;
using eStore.Web.UI.Areas.Store.Controllers;
using eStore.Web.UI.Logic;
using WrapIoC;

namespace eStore.Web.UI
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RouteConfig.RegisterRoutes(RouteTable.Routes);

            BundleConfig.RegisterBundles(BundleTable.Bundles);
            BootstrapBundleConfig.RegisterBundles();

            ServicesBootstraper.Init();

            ControllerBuilder.Current.SetControllerFactory(new ControllerFactory());
            IoC.Current.Register<IController, HomeController>("home");
            IoC.Current.Register<IController, GenreController>("genre");
            IoC.Current.Register<IController, BookController>("book");
            IoC.Current.Register<IController, StoreController>("store");
            IoC.Current.Register<IController, SqlController>("sql");
            IoC.Current.Register<IController, AccountController>("account");

            WebInfraBootstrapper.Init();

            ObjectMapperInitializer.Init();

            ViewEngines.Engines.RemoveAt(0);    // WEB Form engine
        }
    }
}