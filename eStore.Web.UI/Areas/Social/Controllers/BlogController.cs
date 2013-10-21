using System.Web.Mvc;
using eStore.Web.Infrastructure.Filters.Mvc;

namespace eStore.Web.UI.Areas.Social.Controllers
{
    [DbVersion(3)]
    public class BlogController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
