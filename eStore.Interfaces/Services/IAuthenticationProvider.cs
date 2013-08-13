namespace eStore.Interfaces.Services
{
    public interface IAuthenticationProvider
    {
        void SignIn(string userName, bool rememberMe);
        void SignOut();
    }
}
