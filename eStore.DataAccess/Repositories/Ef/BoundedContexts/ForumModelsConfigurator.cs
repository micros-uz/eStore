using System.Data.Entity;
using eStore.DataAccess.Configurations.Social;

namespace eStore.DataAccess.Repositories.Ef.BoundedContexts
{
    public static class ForumModelsConfigurator
    {
        internal static void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new TopicConfiguration());
        }
    }
}
