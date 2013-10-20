using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using eStore.Domain.Store;
using eStore.Interfaces.Services;
using eStore.Web.Infrastructure.ObjectMapper;
using eStore.Web.UI.Areas.Store.ViewModels;
using eStore.Web.UI.Logic;
using eStore.Web.Infrastructure.Filters.Mvc;

namespace eStore.Web.UI.Areas.Store.Controllers
{
    [DbVersion(1)]
    public class HomeController : BaseStoreController
    {
        public HomeController(IStoreService service, IObjectMapper mapper)
            : base(service, mapper)
        {
        }

        public ActionResult Index()
        {
            var books = Service.GetBooksByGenre(9);

            var models = Mapper.Map<IEnumerable<Book>, IEnumerable<BookFullModel>>(books);

            return View(new HomeModel
                {
                    BestSellers = models.Take(3),
                    NewBooks = models
                });
        }

        public ActionResult CurrencySelector()
        {
            var model = new CurrencySelectorModel
            {
                Currencies = new List<CurrencyModel>
                {
                    new CurrencyModel
                    {
                        Name = "US Dollar",
                        ISOCode = "USD",
                        Symbol = "$"
                    },
                    new CurrencyModel
                    {
                        Name = "Сум",
                        ISOCode = "UZS",
                        Symbol = "S"
                    },
                    new CurrencyModel
                    {
                        Name = "Рубль",
                        ISOCode = "RUB",
                        Symbol = "P."
                    }
                }
            };

            return PartialView("_RegionalPane", model);
        }
    }
}
