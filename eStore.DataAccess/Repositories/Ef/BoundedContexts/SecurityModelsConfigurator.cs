using eStore.DataAccess.Configurations.Security;
using System.Data.Entity;

namespace eStore.DataAccess.Repositories.Ef.BoundedContexts
{
    internal static class SecurityModelsConfigurator
    {
        internal static void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new MembershipConfiguration());
            modelBuilder.Configurations.Add(new OAuthMembershipConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
        }
    }
}
