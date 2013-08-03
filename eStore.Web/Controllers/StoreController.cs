using System.Web.Mvc;
using System.Collections.Generic;

namespace eStore.Controllers
{
    public class StoreController : Controller
    {
        public ActionResult Index()
        {
            var list = new List<string>()
            {
                "Romans",
                "Fixions",
                "Novells"
            };

            return View(list);
        }
    }
}
