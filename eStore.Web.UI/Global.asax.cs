using eStore.Core;
using eStore.Web.Infrastructure;
using eStore.Web.Infrastructure.Filters.Mvc;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace eStore.Web.UI
{
    public class MvcApplication : HttpApplication
    {
        protected void Session_Start()
        {
            Session["fefe"] = "newId";
        }

        protected void Session_OnEnd()
        {

        }

        protected void Application_Start()
        {
            RouteTable.Routes.IgnoreRoute("secure/admin/errors");

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FiltersConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            BundleConfig.RegisterBundles(BundleTable.Bundles);

            GlobalConfig.CustomizeConfig(GlobalConfiguration.Configuration);
            ViewEngines.Engines.RemoveAt(0);    // WEB Form engine

            CoreBootstraper.Init();
            WebInfraBootstrapper.Init();

            CoreBootstraper.NotifyDbMigrated();
            
            //FilterProviders.Providers.Add(new FilterProvider());
        }
    }
}