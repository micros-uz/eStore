using eStore.Core;
using eStore.Web.Infrastructure;
using eStore.Web.Infrastructure.Filters.Mvc;
using eStore.Web.UI.Controllers;
using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using NLog;

namespace eStore.Web.UI
{
    public class MvcApplication : HttpApplication
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        protected void Session_Start()
        {
            Session["fefe"] = "newId";
            logger.Info("Session Start");
        }

        protected void Session_OnEnd()
        {
            logger.Info("Session End");
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var httpContext = ((MvcApplication)sender).Context;
            var currentController = " ";
            var currentAction = " ";
            var currentRouteData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));

            if (currentRouteData != null)
            {
                if (currentRouteData.Values["controller"] != null && !String.IsNullOrEmpty(currentRouteData.Values["controller"].ToString()))
                {
                    currentController = currentRouteData.Values["controller"].ToString();
                }

                if (currentRouteData.Values["action"] != null && !String.IsNullOrEmpty(currentRouteData.Values["action"].ToString()))
                {
                    currentAction = currentRouteData.Values["action"].ToString();
                }
            }

            var ex = Server.GetLastError();
            var controller = new ErrorController();
            var routeData = new RouteData();
            var action = "Index";

            if (ex is HttpException)
            {
                var httpEx = ex as HttpException;

                switch (httpEx.GetHttpCode())
                {
                    case 404:
                        action = "NotFound";
                        break;

                    // others if any
                }
            }

            httpContext.ClearError();
            httpContext.Response.Clear();
            httpContext.Response.StatusCode = ex is HttpException ? ((HttpException)ex).GetHttpCode() : 500;
            httpContext.Response.TrySkipIisCustomErrors = true;

            routeData.Values["controller"] = "Error";
            routeData.Values["action"] = action;

            controller.ViewData.Model = new HandleErrorInfo(ex, currentController, currentAction);
            ((IController)controller).Execute(new RequestContext(new HttpContextWrapper(httpContext), routeData));
        }

        protected void Application_Start()
        {
            logger.Info("Application Start");

            RouteTable.Routes.IgnoreRoute("secure/admin/errors");

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FiltersConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //GlobalConfig.CustomizeConfig(GlobalConfiguration.Configuration);
            ViewEngines.Engines.RemoveAt(0);    // WEB Form engine

            CoreBootstraper.Init();
            WebInfraBootstrapper.Init();

            CoreBootstraper.NotifyDbMigrated();
            
            //FilterProviders.Providers.Add(new FilterProvider());
        }

        protected void Application_End()
        {
            logger.Info("Application End");
        }
    }
}