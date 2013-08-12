using System.Web.Mvc;
using eStore.Web.UI.Areas.Account.ViewModels;
using System.Web.Security;

namespace eStore.Web.UI.Areas.Account.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        public ActionResult LogOn(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;

            return View();
        }

        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            FormsAuthentication.SetAuthCookie(model.UserName, true);

            if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            return null;
        }
    }
}
