using eStore.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using eStore.Interfaces.IoC;
using eStore.Web.Controllers;
using eStore.Web.Areas.Admin.Controllers;
using eStore.Core;

namespace eStore.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ControllerBuilder.Current.SetControllerFactory(new ControllerFactory());
            IoC.Current.Register<IController, HomeController>("home");
            IoC.Current.Register<IController, StoreController>("store");
            IoC.Current.Register<IController, SqlController>("sql");

            ServicesBootstrap.Init(IoC.Current);
        }
    }
}