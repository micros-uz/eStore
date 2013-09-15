﻿using System.Collections.Generic;
using System.Web.Mvc;
using eStore.Domain;
using eStore.Interfaces.Services;
using eStore.Web.Infrastructure.ObjectMapper;
using eStore.Web.UI.Areas.Store.ViewModels;
using eStore.Web.UI.Logic;

namespace eStore.Web.UI.Areas.Store.Controllers
{
    [AllowAnonymous]
    public class HomeController : BaseDisposeController
    {
        private readonly IStoreService _service;
        private readonly IObjectMapper _mapper;

        public HomeController(IStoreService service, IObjectMapper mapper)
            :base(service)
        {
            _service = service;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var books = _service.GetBooksByGenre(9);

            var models = _mapper.Map<IEnumerable<Book>, IEnumerable<BookFullModel>>(books);

            return View(new HomeModel
                {
                    BestSellers = models,
                    NewBooks = models
                });
        }
    }
}
