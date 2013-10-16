using System.Collections.Generic;
using System.Web.Mvc;
using eStore.Domain.Store;
using eStore.Interfaces.Services;
using eStore.Web.Infrastructure.ObjectMapper;
using eStore.Web.UI.Areas.Store.ViewModels;
using eStore.Web.UI.Logic;

namespace eStore.Web.UI.Areas.Store.Controllers
{
    public class GenreController : BaseStoreController
    {

        public GenreController(IStoreService service, IObjectMapper objMapper)
            : base(service, objMapper)
        {
        }

        public ActionResult Index()
        {
            return View(GetGenreModels());
        }

        private IEnumerable<GenreModel> GetGenreModels()
        {
            var genres = Service.GetGenres();

            return Mapper.Map<IEnumerable<Genre>, IEnumerable<GenreModel>>(genres);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(GenreFullModel model)
        {
            var genre = Mapper.Map<GenreFullModel, Genre>(model);

            Service.Add(genre);

            //  Post/Redirect/Get pattern
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var genre = Service.GetGenreById(id);

            var model = Mapper.Map<Genre, GenreFullModel>(genre);

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(GenreFullModel model)
        {
            if (ModelState.IsValid)
            {
                var genre = Mapper.Map<GenreFullModel, Genre>(model);

                Service.Update(genre);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Service.DeleteGenreById(id);

            return RedirectToAction("Index");
        }

        [ChildActionOnly]
        public ActionResult Catalog()
        {
            return PartialView("_Genres", GetGenreModels());
        }
    }
}
