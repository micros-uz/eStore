using eStore.Domain.Security;
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

        void IAuthenticationService.Register(User user)
        {
            _authProvider.Register(user);
        }

        #endregion
    }
}
