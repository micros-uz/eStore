using eStore.Interfaces.Services;
using System.Web.Security;

namespace eStore.Web.Infrastructure
{
    public class AuthenticationProvider : IAuthenticationProvider
    {
        #region IAuthenticationProvider

        void IAuthenticationProvider.SignIn(string userName, bool rememberMe)
        {
            FormsAuthentication.SetAuthCookie(userName, rememberMe);
        }

        void IAuthenticationProvider.SignOut()
        {
            FormsAuthentication.SignOut();
        }

        #endregion
    }
}
