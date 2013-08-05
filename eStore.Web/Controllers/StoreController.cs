using System.Web.Mvc;
using System.Collections.Generic;
using eStore.Models;

namespace eStore.Web.Controllers
{
    public class StoreController : Controller
    {
        public ActionResult Index()
        {
            var list = new List<Genre>()
            {
                new Genre(){Title = "Romans"},
                new Genre(){Title = "Fixions"},
                new Genre(){Title = "Novells"}
            };

            return View(list);
        }

        [HttpGet]
        public ActionResult Browse(string title)
        {
            return View();
        }
    }
}
