using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eStore.Web.UI.Areas.Social.ViewModels;

namespace eStore.Web.UI.Areas.Social.Controllers
{
    public class ForumController : Controller
    {
        public ActionResult Index()
        {
            var categories = new List<TopicCategoryModel>()
                {
                    new TopicCategoryModel
                    {
                        Title = "Common Questions",
                        TopicCount = 4,
                        PostCount = 345
                    }
                };

            return View(categories);
        }

    }
}
