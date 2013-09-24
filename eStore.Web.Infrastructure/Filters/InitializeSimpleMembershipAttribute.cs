using System;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace eStore.Web.Infrastructure.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class InitializeSimpleMembershipAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            WebSecurityInitializer.Instance.EnsureInitialize();
        }
    }
}
