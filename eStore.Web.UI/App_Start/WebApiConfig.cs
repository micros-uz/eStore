using System.Web.Http;
using System.Web.Routing;
using eStore.Web.UI.Http;

namespace eStore.Web.UI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            RouteTable.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new
                {
                    action = "Get",
                    controller = "Genre",
                    id = RouteParameter.Optional
                }
            ).RouteHandler = new SessionRouteHandler();
//http://www.codeproject.com/Tips/513522/Providing-session-state-in-ASP-NET-WebAPI
        }
    }
}