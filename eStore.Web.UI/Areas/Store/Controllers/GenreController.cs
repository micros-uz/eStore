using eStore.Domain;
using eStore.Interfaces.Services;
using eStore.Web.Infrastructure.ObjectMapper;
using eStore.Web.UI.Areas.Store.ViewModels;
using eStore.Web.UI.Logic;
using System.Collections.Generic;
using System.Web.Mvc;

namespace eStore.Web.UI.Areas.Store.Controllers
{
    public class GenreController : BaseDisposeController
    {
        private readonly IStoreService _service;
        private readonly IObjectMapper _objMapper;
        public GenreController(IStoreService service, IObjectMapper objMapper)
            : base(service)
        {
            _service = service;
            _objMapper = objMapper;
        }

        public ActionResult Index()
        {
            var genres = _service.GetGenres();

            //var genreModels = Mapper.Map<IEnumerable<Genre>, IEnumerable<GenreModel>>(genres);
            var genreModels = _objMapper.Map<IEnumerable<Genre>, IEnumerable<GenreModel>>(genres);

            return View(genreModels);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(GenreFullModel model)
        {
            var genre = _objMapper.Map<GenreFullModel, Genre>(model);

            _service.Add(genre);

            //  Post/Redirect/Get pattern
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var genre = _service.GetGenreById(id);

            var model = _objMapper.Map<Genre, GenreFullModel>(genre);

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(GenreFullModel model)
        {
            if (ModelState.IsValid)
            {
                var genre = _objMapper.Map<GenreFullModel, Genre>(model);

                _service.Update(genre);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            _service.DeleteGenreById(id);

            return RedirectToAction("Index");
        }
    }
}
