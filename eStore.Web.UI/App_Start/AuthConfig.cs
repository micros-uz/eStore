using Microsoft.Web.WebPages.OAuth;

[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(eStore.Web.UI.AuthConfig), "RegisterAuth")]

namespace eStore.Web.UI
{
    public static class AuthConfig
    {
        public static void RegisterAuth()
        {
            // To let users of this site log in using their accounts from other sites such as Microsoft, Facebook, and Twitter,
            // you must update this site. For more information visit http://go.microsoft.com/fwlink/?LinkID=252166

            OAuthWebSecurity.RegisterMicrosoftClient(
                clientId: "0000000040107204",
                clientSecret: "et9apWcCzqm8ODXYgy53XooaBsw1C895");

            OAuthWebSecurity.RegisterTwitterClient(
                consumerKey: "CnZYU2EWrCSgQ95INafrw",
                consumerSecret: "gOP6mE7RP3dGLDdFOnHqyueyDhbCFl37wa4R0uNpzE");

            OAuthWebSecurity.RegisterFacebookClient(
                appId: "239932299490730",
                appSecret: "d01d385c9449fc5cb1c09c9e4c70a55d");

            OAuthWebSecurity.RegisterYahooClient();

            OAuthWebSecurity.RegisterGoogleClient();
        }
    }
}
