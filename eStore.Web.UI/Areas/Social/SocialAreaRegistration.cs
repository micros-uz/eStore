using System.Web.Mvc;

namespace eStore.Web.UI.Areas.Social
{
    public class SocialAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Social";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRouteLowercase(
                "Social_default",
                "social/{controller}/{action}/{id}",
                new
                {
                    action = "Index",
                    id = UrlParameter.Optional
                }
            );
        }
    }
}
