using System.Web.Http.WebHost;
using System.Web.Routing;
using System.Web.SessionState;

namespace eStore.Web.UI.Http
{
    public class SessionControllerHandler : HttpControllerHandler, IRequiresSessionState
    {
        public SessionControllerHandler(RouteData routeData)
            : base(routeData)
        { }
    }
}