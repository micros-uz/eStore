using System.Web.Mvc;

namespace eStore.Web.UI.Areas.Store
{
    public class StoreAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Store";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            //context.MapRoute(
            //    "Default", string.Empty);

            context.MapRouteLowercase(
                "Store_default",
                "store/{controller}/{action}/{id}",
                new
                {
                    controller = "Home",
                    action = "Index",
                    id = UrlParameter.Optional
                },
                new string[] { "eStore.Web.UI.Areas.Store.Controllers" }
            );

            context.Routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        }
    }
}
