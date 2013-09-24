using System;
using System.Linq;
using System.Web.Security;
using eStore.Interfaces.Repositories;
using WebMatrix.WebData;

namespace eStore.Web.Infrastructure
{
    internal class DatabaseSeedActionManager : ISeedActionProvider
    {
        private readonly IConnectionStringProvider _connStrProvider;

        internal DatabaseSeedActionManager(IConnectionStringProvider connStrProvider)
        {
            _connStrProvider = connStrProvider;
        }

        private void Init()
        {
            if (!WebSecurity.Initialized)
            {
                WebSecurity.InitializeDatabaseConnection(
                    _connStrProvider.ConnectionStringName,
                    "Users",
                    "UserId",
                    "Name", true);

                if (!Roles.RoleExists("Administrator"))
                    Roles.CreateRole("Administrator");

                if (!WebSecurity.UserExists("admin"))
                    WebSecurity.CreateUserAndAccount(
                        "admin",
                        "123");

                if (!Roles.GetRolesForUser("admin").Contains("Administrator"))
                    Roles.AddUsersToRoles(new[] { "admin" }, new[] { "Administrator" });
            }
        }

        #region ISeedActionProvider

        public Action Action
        {
            get { return () => Init(); }
        }

        #endregion
    }
}
