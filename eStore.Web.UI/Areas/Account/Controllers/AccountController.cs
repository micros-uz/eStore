using System.Web.Mvc;
using eStore.Domain.Security;
using System.Linq;
using eStore.Interfaces.Services;
using eStore.Web.Infrastructure.Filters;
using eStore.Web.Infrastructure.ObjectMapper;
using eStore.Web.UI.Areas.Account.ViewModels;
using eStore.Web.UI.Logic;
using Microsoft.Web.WebPages.OAuth;
using DotNetOpenAuth.AspNet;
using eStore.Web.Infrastructure.Filters.Mvc;

namespace eStore.Web.UI.Areas.Account.Controllers
{
    [AuthorizeEx]
    [DbVersion(2)]
    public class AccountController : BaseDisposeController
    {
        private readonly IAuthenticationService _authService;
        private readonly IUserService _userService;
        private readonly IObjectMapper _objMapper;

        public AccountController(IAuthenticationService authService,
            IUserService userService, IObjectMapper objMapper) :
            base(userService)
        {
            _authService = authService;
            _userService = userService;
            _objMapper = objMapper;
        }

        [AllowAnonymous]
        public ActionResult LogOn(string returnUrl)
        {
            ViewBag.ReturnUrl = string.IsNullOrEmpty(returnUrl)
                ? (Request.UrlReferrer != null
                    ? Request.UrlReferrer.AbsolutePath
                    : "/")
                : returnUrl;

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

        //[ValidateAntiForgeryToken]
        //[HttpPost]
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
                    _authService.Register(model.Name, model.Password, "Client");
                    _authService.LogOn(model.Name, model.Password, false);

                    return RedirectToAction("Index", "Home", new { area = "store" });
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

        [ChildActionOnly]
        public ActionResult AccountSubMenu()
        {
            return PartialView();
        }

        #region External Login

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            return new ExternalLoginResult(provider, Url.Action("ExternalLoginCallback", new { ReturnUrl = returnUrl }));
        }

        [AllowAnonymous]
        [ChildActionOnly]
        public ActionResult ExternalLoginsList(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return PartialView("_ExternalLogins", OAuthWebSecurity.RegisteredClientData);
        }

        [AllowAnonymous]
        public ActionResult ExternalLoginCallback(string returnUrl)
        {
            AuthenticationResult result = OAuthWebSecurity.VerifyAuthentication(Url.Action("ExternalLoginCallback", new { ReturnUrl = returnUrl }));
            if (!result.IsSuccessful)
            {
                return RedirectToAction("ExternalLoginFailure");
            }

            if (OAuthWebSecurity.Login(result.Provider, result.ProviderUserId, createPersistentCookie: false))
            {
                return RedirectToLocal(returnUrl);
            }

            if (User.Identity.IsAuthenticated)
            {
                // If the current user is logged in add the new account
                OAuthWebSecurity.CreateOrUpdateAccount(result.Provider, result.ProviderUserId, User.Identity.Name);
                return RedirectToLocal(returnUrl);
            }
            else
            {
                // User is new, ask for their desired membership name
                string loginData = OAuthWebSecurity.SerializeProviderUserId(result.Provider, result.ProviderUserId);
                ViewBag.ProviderDisplayName = OAuthWebSecurity.GetOAuthClientData(result.Provider).DisplayName;
                ViewBag.ReturnUrl = returnUrl;
                return View("ExternalLoginConfirmation", new RegisterExternalLoginModel { UserName = result.UserName, ExternalLoginData = loginData });
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLoginConfirmation(RegisterExternalLoginModel model, string returnUrl)
        {
            string provider = null;
            string providerUserId = null;

            if (User.Identity.IsAuthenticated || !OAuthWebSecurity.TryDeserializeProviderUserId(model.ExternalLoginData, out provider, out providerUserId))
            {
                return RedirectToAction("Manage");
            }

            if (ModelState.IsValid)
            {
                var user = _userService.Users.FirstOrDefault(x => x.Name.ToLower() == model.UserName.ToLower());

                if (user == null)
                {
                    _userService.AddUser(new User
                        {
                            Name = model.UserName
                        });

                    OAuthWebSecurity.CreateOrUpdateAccount(provider, providerUserId, model.UserName);
                    OAuthWebSecurity.Login(provider, providerUserId, createPersistentCookie: false);

                    return RedirectToLocal(returnUrl);

                }
                else
                {
                    ModelState.AddModelError("UserName", "User name already exists. Please enter a different user name.");
                }
            }

            ViewBag.ProviderDisplayName = OAuthWebSecurity.GetOAuthClientData(provider).DisplayName;
            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        internal class ExternalLoginResult : ActionResult
        {
            public ExternalLoginResult(string provider, string returnUrl)
            {
                Provider = provider;
                ReturnUrl = returnUrl;
            }

            public string Provider { get; private set; }
            public string ReturnUrl { get; private set; }

            public override void ExecuteResult(ControllerContext context)
            {
                OAuthWebSecurity.RequestAuthentication(Provider, ReturnUrl);
            }
        }     
   
        #endregion


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
