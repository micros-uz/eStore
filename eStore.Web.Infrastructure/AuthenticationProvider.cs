using eStore.Interfaces.Services;
using System.Web.Security;
using WebMatrix.WebData;

namespace eStore.Web.Infrastructure
{
    public class AuthenticationProvider : IAuthenticationProvider
    {
        #region IAuthenticationProvider

        void IAuthenticationProvider.SignIn(string userName, string password, bool rememberMe)
        {
            //FormsAuthentication.SetAuthCookie(userName, rememberMe);
            WebSecurity.Login(userName, password, rememberMe);
        }

        void IAuthenticationProvider.SignOut()
        {
            //FormsAuthentication.SignOut();
            WebSecurity.Logout();
        }

        #endregion
    }
}
