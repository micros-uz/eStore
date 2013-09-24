namespace eStore.Interfaces.Services
{
    public interface IAuthenticationProvider
    {
        bool SignIn(string userName, string password, bool rememberMe);
        void SignOut();
    }
}
