using System.Collections.Generic;
using System.Web.Mvc;
using eStore.Domain;
using eStore.Interfaces.Services;
using eStore.Web.Infrastructure.ObjectMapper;
using eStore.Web.UI.Areas.Admin.ViewModels;

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

            var userModels = _objMapper.Map<IEnumerable<User>, IEnumerable<UserModel>>(users);

            return View(userModels);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _objMapper.Map<UserModel, User>(model);

                _service.AddUser(user);

                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult Details(int id)
        {
            var model = GetUserModel(id);

            if (model != null)
            {
                return View(model);
            }
            else
            {
                return null;
            }
        }

        private UserModel GetUserModel(int id)
        {
            UserModel res = null;

            var user = _service.GetUserById(id);

            if (user != null)
            {
                res = _objMapper.Map<User, UserModel>(user);
            }

            return res;
        }

        public ActionResult Edit(int id)
        {
            var model = GetUserModel(id);

            if (model != null)
            {
                return View(model);
            }
            else
            {
                return null;
            }
        }

        [HttpPost]
        public ActionResult Edit(UserModel model)
        {
            if (ModelState.IsValid)
            {

                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }
    }
}
