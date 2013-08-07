using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace eStore.Web
{
    /// <summary>
    /// Contains extension methods to map routes in Areas to lowercase URLs.
    /// </summary>
    public static class AreaRegistrationContextExtensions
    {
        /// <summary>
        /// Maps the specified URL route using a lowercase URL and associates it with the area that is specified by the AreaName property. Does not change casing in the querystring, if any.
        /// </summary>
        /// <param name="context">The context that encapsulates the information that is required in order to register an area within an ASP.NET MVC application.</param>
        /// <param name="name">The name of the route.</param>
        /// <param name="url">The URL pattern for the route.</param>
        /// <returns>A reference to the mapped route.</returns>
        public static Route MapRouteLowercase(this AreaRegistrationContext context, string name, string url)
        {
            return MapRouteLowercase(context, name, url, null, null, null);
        }

        /// <summary>
        /// Maps the specified URL route using a lowercase URL and associates it with the area that is specified by the AreaName property, using the specified route default values. Does not change casing in the querystring, if any.
        /// </summary>
        /// <param name="context">The context that encapsulates the information that is required in order to register an area within an ASP.NET MVC application.</param>
        /// <param name="name">The name of the route.</param>
        /// <param name="url">The URL pattern for the route.</param>
        /// <param name="defaults">An object that contains default route values.</param>
        /// <returns>A reference to the mapped route.</returns>
        public static Route MapRouteLowercase(this AreaRegistrationContext context, string name, string url, object defaults)
        {
            return MapRouteLowercase(context, name, url, defaults, null, null);
        }

        /// <summary>
        /// Maps the specified URL route using a lowercase URL and associates it with the area that is specified by the AreaName property, using the specified namespaces. Does not change casing in the querystring, if any.
        /// </summary>
        /// <param name="context">The context that encapsulates the information that is required in order to register an area within an ASP.NET MVC application.</param>
        /// <param name="name">The name of the route.</param>
        /// <param name="url">The URL pattern for the route.</param>
        /// <param name="namespaces">A set of namespaces for the application.</param>
        /// <returns>A reference to the mapped route.</returns>
        public static Route MapRouteLowercase(this AreaRegistrationContext context, string name, string url, string[] namespaces)
        {
            return MapRouteLowercase(context, name, url, null, null, namespaces);
        }

        /// <summary>
        /// Maps the specified URL route using a lowercase URL and associates it with the area that is specified by the AreaName property, using the specified route default values and constraints. Does not change casing in the querystring, if any.
        /// </summary>
        /// <param name="context">The context that encapsulates the information that is required in order to register an area within an ASP.NET MVC application.</param>
        /// <param name="name">The name of the route.</param>
        /// <param name="url">The URL pattern for the route.</param>
        /// <param name="defaults">An object that contains default route values.</param>
        /// <param name="constraints">A set of expressions that specify valid values for a URL parameter.</param>
        /// <returns>A reference to the mapped route.</returns>
        public static Route MapRouteLowercase(this AreaRegistrationContext context, string name, string url, object defaults, object constraints)
        {
            return MapRouteLowercase(context, name, url, defaults, constraints, null);
        }

        /// <summary>
        /// Maps the specified URL route using a lowercase URL and associates it with the area that is specified by the AreaName property, using the specified route default values and namespaces. Does not change casing in the querystring, if any.
        /// </summary>
        /// <param name="context">The context that encapsulates the information that is required in order to register an area within an ASP.NET MVC application.</param>
        /// <param name="name">The name of the route.</param>
        /// <param name="url">The URL pattern for the route.</param>
        /// <param name="defaults">An object that contains default route values.</param>
        /// <param name="namespaces">A set of namespaces for the application.</param>
        /// <returns>A reference to the mapped route.</returns>
        public static Route MapRouteLowercase(this AreaRegistrationContext context, string name, string url, object defaults, string[] namespaces)
        {
            return MapRouteLowercase(context, name, url, defaults, null, namespaces);
        }

        /// <summary>
        /// Maps the specified URL route using a lowercase URL and associates it with the area that is specified by the AreaName property, using the specified route default values, constraints, and namespaces. Does not change casing in the querystring, if any.
        /// </summary>
        /// <param name="context">The context that encapsulates the information that is required in order to register an area within an ASP.NET MVC application.</param>
        /// <param name="name">The name of the route.</param>
        /// <param name="url">The URL pattern for the route.</param>
        /// <param name="defaults">An object that contains default route values.</param>
        /// <param name="constraints">A set of expressions that specify valid values for a URL parameter.</param>
        /// <param name="namespaces">A set of namespaces for the application.</param>
        /// <returns>A reference to the mapped route.</returns>
        public static Route MapRouteLowercase(this AreaRegistrationContext context, string name, string url, object defaults, object constraints, string[] namespaces)
        {
            if (namespaces == null && context.Namespaces != null)
            {
                namespaces = context.Namespaces.ToArray();
            }

            Route route = context.Routes.MapRouteLowercase(name, url, defaults, constraints, namespaces);

            route.DataTokens["area"] = context.AreaName;
            route.DataTokens["UseNamespaceFallback"] = (namespaces == null || namespaces.Length == 0);

            return route;
        }
    }

    /// <summary>
    /// Contains extension methods to map routes to lowercase URLs.
    /// </summary>
    public static class RouteCollectionExtensions
    {
        /// <summary>
        /// Maps the specified URL route using a lowercase URL. Does not change casing in the querystring, if any.
        /// </summary>
        /// <param name="routes">A collection of routes for the application.</param>
        /// <param name="name">The name of the route to map.</param>
        /// <param name="url">The URL pattern for the route.</param>
        /// <returns>A reference to the mapped route.</returns>
        public static Route MapRouteLowercase(this RouteCollection routes, string name, string url)
        {
            return MapRouteLowercase(routes, name, url, null, null, null);
        }

        /// <summary>
        /// Maps the specified URL route using a lowercase URL and sets default route values. Does not change casing in the querystring, if any.
        /// </summary>
        /// <param name="routes">A collection of routes for the application.</param>
        /// <param name="name">The name of the route to map.</param>
        /// <param name="url">The URL pattern for the route.</param>
        /// <param name="defaults">An object that contains default route values.</param>
        /// <returns>A reference to the mapped route.</returns>
        public static Route MapRouteLowercase(this RouteCollection routes, string name, string url, object defaults)
        {
            return MapRouteLowercase(routes, name, url, defaults, null, null);
        }

        /// <summary>
        /// Maps the specified URL route using a lowercase URL and sets the namespaces. Does not change casing in the querystring, if any.
        /// </summary>
        /// <param name="routes">A collection of routes for the application.</param>
        /// <param name="name">The name of the route to map.</param>
        /// <param name="url">The URL pattern for the route.</param>
        /// <param name="namespaces">A set of namespaces for the application.</param>
        /// <returns>A reference to the mapped route.</returns>
        public static Route MapRouteLowercase(this RouteCollection routes, string name, string url, string[] namespaces)
        {
            return MapRouteLowercase(routes, name, url, null, null, namespaces);
        }

        /// <summary>
        /// Maps the specified URL route using a lowercase URL and sets default route values and constraints. Does not change casing in the querystring, if any.
        /// </summary>
        /// <param name="routes">A collection of routes for the application.</param>
        /// <param name="name">The name of the route to map.</param>
        /// <param name="url">The URL pattern for the route.</param>
        /// <param name="defaults">An object that contains default route values.</param>
        /// <param name="constraints">A set of expressions that specify valid values for a URL parameter.</param>
        /// <returns>A reference to the mapped route.</returns>
        public static Route MapRouteLowercase(this RouteCollection routes, string name, string url, object defaults, object constraints)
        {
            return MapRouteLowercase(routes, name, url, defaults, constraints, null);
        }

        /// <summary>
        /// Maps the specified URL route using a lowercase URL and sets default route values and namespaces. Does not change casing in the querystring, if any.
        /// </summary>
        /// <param name="routes">A collection of routes for the application.</param>
        /// <param name="name">The name of the route to map.</param>
        /// <param name="url">The URL pattern for the route.</param>
        /// <param name="defaults">An object that contains default route values.</param>
        /// <param name="namespaces">A set of namespaces for the application.</param>
        /// <returns>A reference to the mapped route.</returns>
        public static Route MapRouteLowercase(this RouteCollection routes, string name, string url, object defaults, string[] namespaces)
        {
            return MapRouteLowercase(routes, name, url, defaults, null, namespaces);
        }

        /// <summary>
        /// Maps the specified URL route and sets default route values, constraints, and namespaces. Does not change casing in the querystring, if any.
        /// </summary>
        /// <param name="routes">A collection of routes for the application.</param>
        /// <param name="name">The name of the route to map.</param>
        /// <param name="url">The URL pattern for the route.</param>
        /// <param name="defaults">An object that contains default route values.</param>
        /// <param name="constraints">A set of expressions that specify valid values for a URL parameter.</param>
        /// <param name="namespaces">A set of namespaces for the application.</param>
        /// <returns>A reference to the mapped route.</returns>
        public static Route MapRouteLowercase(this RouteCollection routes, string name, string url, object defaults, object constraints, string[] namespaces)
        {
            if (routes == null)
            {
                throw new ArgumentNullException("routes");
            }

            if (url == null)
            {
                throw new ArgumentNullException("url");
            }

            var route = new LowercaseRoute(url, new MvcRouteHandler())
            {
                Defaults = new RouteValueDictionary(defaults),
                Constraints = new RouteValueDictionary(constraints),
                DataTokens = new RouteValueDictionary(namespaces),
            };

            if (namespaces != null && namespaces.Length > 0)
            {
                route.DataTokens["Namespaces"] = namespaces;
            }

            routes.Add(name, route);

            return route;
        }
    }
    internal class LowercaseRoute : Route
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
            {
                string virtualPath = path.VirtualPath;
                var lastIndexOf = virtualPath.LastIndexOf("?");

                if (lastIndexOf != 0)
                {
                    if (lastIndexOf > 0)
                    {
                        string leftPart = virtualPath.Substring(0, lastIndexOf).ToLowerInvariant();
                        string queryPart = virtualPath.Substring(lastIndexOf);
                        path.VirtualPath = leftPart + queryPart;
                    }
                    else
                    {
                        path.VirtualPath = path.VirtualPath.ToLowerInvariant();
                    }
                }
            }

            return path;
        }
    }
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRouteLowercase(
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