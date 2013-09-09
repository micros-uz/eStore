using System.Web.Mvc;

namespace eStore.Web.UI.Areas.Store.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
