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
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ViewEngines.Engines.RemoveAt(0);    // WEB Form engine
        }
    }
}