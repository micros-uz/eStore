using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eStore.Web.UI.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult DbVersionInvalid()
        {
            return View();
        }
    }
}
