using System.Web.Mvc;
using eStore.Web.UI.Areas.Account.ViewModels;
using System.Web.Security;
using eStore.Interfaces.Services;
using eStore.Domain;
using System;
using System.Linq;
using AutoMapper;

namespace eStore.Web.UI.Areas.Account.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IAuthenticationService _authService;
        private readonly IUserService _userService;

        public AccountController(IAuthenticationService authService,
            IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        [AllowAnonymous]
        public ActionResult LogOn(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;

            return View(new LogOnModel());
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (_authService.LogOn(model.Name, model.Password, model.RememberMe))

                if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                    && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home", new { area = "store" });
                }
            }
            else
            {
                ModelState.AddModelError("", "The user name or password provided is incorrect.");
            }

            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult LogOff()
        {
            _authService.LogOff();

            return RedirectToAction("Index", "Home", new { area = "store" });
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            FillRoles();

            return View(new RegisterModel());
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Password.Equals(model.PasswordConfirm))
                {
                    var user = Mapper.Map<RegisterModel, User>(model);
                    _userService.AddUser(user);

                    return RedirectToAction("LogOn");
                }
                else
                {
                    ModelState.AddModelError("", "Password confirmation mismatch");
                }

                return View(model);
            }
            else
            {
                ModelState.AddModelError("", "Some fields are not filled properly");
                return View(model);
            }
        }

        /*
         * 
         * Private methods
         */

        private void FillRoles()
        {
            ViewBag.RoleList = new SelectList(_userService.Roles, "RoleId", "Name");
        }
    }
}
