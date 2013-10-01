using System.Collections.Generic;

namespace eStore.Web.Infrastructure.Authentication
{
    public static class OAuthSettingsProvider
    {
        private static Dictionary<string, OAuthSecretData> _Settings;

        static OAuthSettingsProvider()
        {
            _Settings = new Dictionary<string, OAuthSecretData>();

            _Settings.Add("microsoft", new OAuthSecretData
                    {
                        Id =  "0000000040107204",
                        Secret = "et9apWcCzqm8ODXYgy53XooaBsw1C895"
                    });
            _Settings.Add("twitter", new OAuthSecretData
                    {
                        Id = "CnZYU2EWrCSgQ95INafrw",
                        Secret = "gOP6mE7RP3dGLDdFOnHqyueyDhbCFl37wa4R0uNpzE"
                    });
            _Settings.Add("facebook", new OAuthSecretData
                    {
                        Id = "239932299490730",
                        Secret = "d01d385c9449fc5cb1c09c9e4c70a55d"
                    });
            _Settings.Add("linkedin", new OAuthSecretData
                    {
                        Id = "udsaykvhuab2",
                        Secret = "guSGD2ay0Qmk81nD"
                    });
        }

        public static Dictionary<string, OAuthSecretData> Settings
        {
            get
            {
                return _Settings;
            }
        }
    }
}
