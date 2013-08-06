using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace eStore.Web
{
    internal static class RouteCollectionExtensions
    {
        public static Route MapLowercaseRoute(this RouteCollection routes, string name, string url, object defaults)
        {
            return MapLowercaseRoute(routes, name, url, defaults, null);
        }

        public static Route MapLowercaseRoute(this RouteCollection routes, string name, string url, object defaults, object constraints)
        {
            if (routes == null)
                throw new ArgumentNullException("routes");
            if (url == null)
                throw new ArgumentNullException("url");

            LowercaseRoute route = new LowercaseRoute(url, new MvcRouteHandler())
            {
                Defaults = new RouteValueDictionary(defaults),
                Constraints = new RouteValueDictionary(constraints),
                DataTokens = new RouteValueDictionary()
            };

            routes.Add(name, route);

            return route;
        }
    }

    internal class LowercaseRoute : System.Web.Routing.Route
    {
        public LowercaseRoute(string url, IRouteHandler routeHandler)
            : base(url, routeHandler)
        {
        }
        public LowercaseRoute(string url, RouteValueDictionary defaults, IRouteHandler routeHandler)
            : base(url, defaults, routeHandler)
        {
        }
        public LowercaseRoute(string url, RouteValueDictionary defaults, RouteValueDictionary constraints, IRouteHandler routeHandler)
            : base(url, defaults, constraints, routeHandler)
        {
        }
        public LowercaseRoute(string url, RouteValueDictionary defaults, RouteValueDictionary constraints, RouteValueDictionary dataTokens, IRouteHandler routeHandler)
            : base(url, defaults, constraints, dataTokens, routeHandler)
        {
        }

        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
            VirtualPathData path = base.GetVirtualPath(requestContext, values);

            if (path != null)
                path.VirtualPath = path.VirtualPath.ToLowerInvariant();

            return path;
        }
    }

    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapLowercaseRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new
                {
                    controller = "Home",
                    action = "Index",
                    id = UrlParameter.Optional
                }
            );
        }
    }
}