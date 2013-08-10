using System.Collections.Generic;
using System.Web.Mvc;
using eStore.Interfaces.Services;
using eStore.Domain;
using AutoMapper;
using eStore.Web.ViewModels;

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
            var genres = _Service.GetGenres();
            Mapper.CreateMap<Genre, GenreModel>();
            var genreModels = Mapper.Map<IEnumerable<Genre>,IEnumerable<GenreModel>>(genres);

            return View(genreModels);
        }

        [HttpGet]
        public ActionResult Browse(int genreId)
        {
            _Service.GetBooksByGenre(genreId);

            return View();
        }
    }
}
