using System.Web.Mvc;

namespace eStore.Web.UI.Areas.Account
{
    public class AccountAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Account";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRouteLowercase(
                "Account_default",
                "account/{controller}/{action}/{id}",
                new {  id = UrlParameter.Optional }
            );
        }
    }
}
