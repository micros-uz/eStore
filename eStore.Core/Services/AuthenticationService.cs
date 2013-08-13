using eStore.Domain;
using eStore.Interfaces.Services;

namespace eStore.Core.Services
{
    internal class AuthenticationService : IAuthenticationService
    {
        private IAuthenticationProvider _authProvider;
        public AuthenticationService(IAuthenticationProvider authProvider)
        {
            _authProvider = authProvider;
        }

        #region IAthenticationService

        bool IAuthenticationService.LogOn(string userName, string password, bool rememberMe)
        {
            if (userName == "admin" && password == "123")
            {
                _authProvider.SignIn(userName, rememberMe);
                return true;
            }

            return false;
        }

        void IAuthenticationService.LogOff()
        {
            _authProvider.SignOut();
        }

        #endregion
    }
}
