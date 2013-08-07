using System.Collections.Generic;
using System.Web.Mvc;
using eStore.Interfaces.Services;
using eStore.Models;

namespace eStore.Web.Controllers
{
    public class StoreController : Controller
    {
        private IStoreService _Service;

        public StoreController(IStoreService service)
        {
            _Service = service;
        }

        public ActionResult Index()
        {
            //var list = new List<Genre>()
            //{
            //    new Genre(){Title = "Romans"},
            //    new Genre(){Title = "Fixions"},
            //    new Genre(){Title = "Novells"}
            //};

            return View(_Service.GetGenres());
        }

        [HttpGet]
        public ActionResult Browse(int genreId)
        {
            _Service.GetBooksByGenre(genreId);

            return View();
        }
    }
}
