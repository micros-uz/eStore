using eStore.Web.UI.Areas.Account.ViewModels;
using System.Web.Mvc;

namespace eStore.Web.UI.Areas.Account.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult LogOn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(LogOnModel model)
        {
            return null;
        }
    }
}
