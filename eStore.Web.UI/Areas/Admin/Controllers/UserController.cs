using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using eStore.Domain;
using eStore.Interfaces.Services;
using eStore.Web.Infrastructure;
using eStore.Web.Infrastructure.ObjectMapper;
using eStore.Web.UI.Areas.Admin.ViewModels;

namespace eStore.Web.UI.Areas.Admin.Controllers
{
    public class Paging
    {
        public int PageNumber { get; set; }
        public int TotalPagesCount { get; set; }
    }

    public class PagingData
    {
        public int PageNumber { get; set; }
        public int TotalPagesCount { get; set; }
    }

    public class ListResult
    {
        public IEnumerable<UserModel> Data { get; set; }
        public Paging Paging { get; set; }
    }

    public class UserController : BaseMvcController
    {
        private const int PageSize = 10;

        private readonly IUserService _service;
        private readonly IObjectMapper _objMapper;
        public UserController(IUserService service, IObjectMapper objMapper)
        {
            _service = service;
            _objMapper = objMapper;
        }

        public ActionResult Index()
        {
            return View(new FilterParams());
        }

        public ActionResult UserList(FilterParams filterParams, int pageNumber = 1)
        {
            var users = _service.Users;

            var userModels = _objMapper.Map<IEnumerable<User>, IEnumerable<UserModel>>(users);

            IEnumerable<UserModel> data = userModels;

            if (filterParams.Role.HasValue)
            {
                data = data.Where(r => r.RoleId == filterParams.Role.Value);
            }
            var roles = new List<int>();
            if (filterParams.ShowAdmins)
            {
                roles.Add(1);
            }
            if (filterParams.ShowManagers)
            {
                roles.Add(2);
            }

            data = data.Where(r => roles.Contains(r.RoleId));

            var paging = new Paging();
            paging.PageNumber = pageNumber;
            paging.TotalPagesCount = (int)Math.Ceiling(1D * data.Count() / PageSize);

            data = data.Skip((pageNumber - 1) * PageSize).Take(PageSize);
            return Json(new ListResult { Data = data, Paging = paging });
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
