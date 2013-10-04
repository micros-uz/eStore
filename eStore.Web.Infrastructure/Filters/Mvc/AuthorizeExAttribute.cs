using System.Web;
using System.Web.Mvc;

namespace eStore.Web.Infrastructure.Filters.Mvc
{
    public class AuthorizeExAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return base.AuthorizeCore(httpContext);
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
        }
    }
}
