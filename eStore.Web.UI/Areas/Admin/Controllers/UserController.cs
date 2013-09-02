using eStore.Domain;
using eStore.Interfaces.Services;
using eStore.Web.Infrastructure.ObjectMapper;
using eStore.Web.UI.Areas.Admin.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace eStore.Web.UI.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _service;
        private readonly IObjectMapper _objMapper;
        public UserController(IUserService service, IObjectMapper objMapper)
        {
            _service = service;
            _objMapper = objMapper;
        }
        public ActionResult Index()
        {
            var users = _service.Users;

            var userModels = _objMapper.Map < IEnumerable<User>, IEnumerable<UserModel>>(users);

            return View(userModels);
        }

    }
}
