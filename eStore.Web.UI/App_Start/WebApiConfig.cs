using System.Web.Http;

namespace eStore.Web.UI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new
                {
                    action = "Get",
                    controller = "Genre",
                    id = RouteParameter.Optional
                }
            );
        }
    }
}