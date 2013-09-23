namespace eStore.Interfaces.Services
{
    public interface IAuthenticationProvider
    {
        void SignIn(string userName, string password, bool rememberMe);
        void SignOut();
    }
}
