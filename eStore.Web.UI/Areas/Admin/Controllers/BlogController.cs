using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eStore.Web.UI.Areas.Admin.Controllers
{
    public class BlogController : Controller
    {
        //
        // GET: /Admin/Blog/

        public ActionResult Index()
        {
            return View();
        }

    }
}
