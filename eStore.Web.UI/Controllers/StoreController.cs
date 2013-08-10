using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using eStore.Domain;
using eStore.Interfaces.Services;
using eStore.Web.UI.ViewModels;

namespace eStore.Web.UI.Controllers
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
            var genres = _Service.GetGenres();
            Mapper.CreateMap<Genre, GenreModel>();
            var genreModels = Mapper.Map<IEnumerable<Genre>, IEnumerable<GenreModel>>(genres);

            return View(genreModels);
        }

        [HttpGet]
        public ActionResult Browse(int id)
        {
            _Service.GetBooksByGenre(id);

            return View();
        }
    }
}
