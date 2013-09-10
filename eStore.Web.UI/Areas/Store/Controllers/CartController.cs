using System.Collections.Generic;
using System.Web.Mvc;
using eStore.Web.UI.Areas.Store.ViewModels;

namespace eStore.Web.UI.Areas.Store.Controllers
{
    public class CartController : Controller
    {
        public ActionResult Index()
        {
            return View(new List<CartItemModel>());
        }

        public JsonResult Add(int id)
        {
            return Json(new { count = 3 }, JsonRequestBehavior.AllowGet);
        }
    }
}
