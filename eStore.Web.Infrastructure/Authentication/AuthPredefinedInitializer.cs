using System.Web.Security;
using eStore.Interfaces.Data;
using WebMatrix.WebData;

namespace eStore.Web.Infrastructure.Authentication
{
    internal class AuthPredefinedInitializer : IMigrationInitializer
    {
        #region IMigrationInitializer

        void IMigrationInitializer.Run()
        {
            string[] users = new string[] { "ibragim", "john", "sergey", "Ruslan", 
                    "Kate", "lee123"};

            foreach (var user in users)
            {
                WebSecurity.CreateUserAndAccount(user, "mypassword");
            }

            Roles.AddUsersToRole(users, "Client");
        }

        #endregion
    }
}
