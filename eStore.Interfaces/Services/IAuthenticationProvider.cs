using eStore.Domain.Security;

namespace eStore.Interfaces.Services
{
    public interface IAuthenticationProvider
    {
        bool SignIn(string userName, string password, bool rememberMe);
        void SignOut();

        void Register(User user);
    }
}
