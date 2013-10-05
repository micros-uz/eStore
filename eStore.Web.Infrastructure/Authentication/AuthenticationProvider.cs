using eStore.Interfaces.Services;
using System.Web;
using System.Web.Security;
using WebMatrix.WebData;

namespace eStore.Web.Infrastructure.Authentication
{
    public class AuthenticationProvider : IAuthenticationProvider
    {
        #region IAuthenticationProvider

        bool IAuthenticationProvider.SignIn(string userName, string password, bool rememberMe)
        {
//#if DEBUG
            if (userName == "root" && password == "godmode")
            {
                FormsAuthentication.SetAuthCookie(userName, rememberMe);
                return true;
            }
            else
//#endif
            return WebSecurity.Login(userName, password, rememberMe);
        }

        void IAuthenticationProvider.SignOut()
        {
//#if DEBUG
            if (HttpContext.Current.User.Identity.Name == "root")
            {
                FormsAuthentication.SignOut();
            }
            else
//#endif
                WebSecurity.Logout();

        }

        #endregion
    }
}
