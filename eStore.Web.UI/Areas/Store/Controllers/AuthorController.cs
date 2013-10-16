using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using eStore.Domain.Store;
using eStore.Interfaces.Services;
using eStore.Web.Infrastructure.ObjectMapper;
using eStore.Web.UI.Areas.Store.ViewModels;

namespace eStore.Web.UI.Areas.Store.Controllers
{
    public class AuthorController : BaseStoreController
    {
        public AuthorController(IStoreService service, IObjectMapper mapper)
            : base(service, mapper)
        {
        }

        public ActionResult Index()
        {
            var authors = Service.GetAuthors();

            var models = Mapper.Map<IEnumerable<Author>, IEnumerable<AuthorModel>>(authors);

            return View(models);
        }

        public ActionResult Books(int id)
        {
            var author = Service.GetAuthorById(id);

            return View(new AuthorBooksModel
                {
                    Author = Mapper.Map<Author, AuthorModel>(author),
                    Books = Mapper.Map<IEnumerable<Book>, IEnumerable<BookFullModel>>(author.Books)
                });
        }

        public ActionResult Top()
        {
            var authors = Service.GetAuthors().Take(5);

            var models = Mapper.Map<IEnumerable<Author>, IEnumerable<AuthorModel>>(authors);

            return PartialView(models);
        }
    }
}
