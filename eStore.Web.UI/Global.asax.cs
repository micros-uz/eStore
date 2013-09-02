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
using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace eStore.Web.UI
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ViewEngines.Engines.RemoveAt(0);    // WEB Form engine
        }
    }
}