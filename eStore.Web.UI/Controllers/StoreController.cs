using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EmitMapper;
using eStore.Domain;
using eStore.Interfaces.Services;
using eStore.Web.UI.ViewModels;
using EmitMapper.MappingConfiguration;
using System;
using System.Reflection;
using System.Linq.Expressions;
using EmitMapper.MappingConfiguration.MappingOperations;
using EmitMapper.Utils;
using System.Diagnostics;
using AutoMapper;

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
            var books = _Service.GetBooksByGenre(id);
            Mapper.CreateMap<Book, BookModel>().ForMember(x => x.Author, x => x.MapFrom(w => w.Author.Name));
            var bookModels = Mapper.Map<IEnumerable<Book>, IEnumerable<BookModel>>(books);

            return View(bookModels);
        }
    }
}
