using eStore.Web.Infrastructure;
using eStore.Web.Infrastructure.Authentication;
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
                OAuthSettingsProvider.Settings["microsoft"].Id,
                OAuthSettingsProvider.Settings["microsoft"].Secret
                //clientId: "0000000040107204",
                //clientSecret: "et9apWcCzqm8ODXYgy53XooaBsw1C895"
            );

            OAuthWebSecurity.RegisterTwitterClient(
                OAuthSettingsProvider.Settings["twitter"].Id,
                OAuthSettingsProvider.Settings["twitter"].Secret

                //consumerKey: "CnZYU2EWrCSgQ95INafrw",
                //consumerSecret: "gOP6mE7RP3dGLDdFOnHqyueyDhbCFl37wa4R0uNpzE"
            );

            OAuthWebSecurity.RegisterLinkedInClient(
                OAuthSettingsProvider.Settings["linkedin"].Id,
                OAuthSettingsProvider.Settings["linkedin"].Secret);

            OAuthWebSecurity.RegisterFacebookClient(
                OAuthSettingsProvider.Settings["facebook"].Id,
                OAuthSettingsProvider.Settings["facebook"].Secret

                //appId: "239932299490730",
                //appSecret: "d01d385c9449fc5cb1c09c9e4c70a55d"
            );

            OAuthWebSecurity.RegisterYahooClient();

            OAuthWebSecurity.RegisterGoogleClient();

        }
    }
}
