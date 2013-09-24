using eStore.Interfaces.Services;

namespace eStore.Core.Services
{
    internal class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthenticationProvider _authProvider;

        public AuthenticationService(IAuthenticationProvider authProvider)
        {
            _authProvider = authProvider;
        }

        #region IAthenticationService

        bool IAuthenticationService.LogOn(string userName, string password, bool rememberMe)
        {
            return _authProvider.SignIn(userName, password, rememberMe);
        }

        void IAuthenticationService.LogOff()
        {
            _authProvider.SignOut();
        }

        #endregion
    }
}
