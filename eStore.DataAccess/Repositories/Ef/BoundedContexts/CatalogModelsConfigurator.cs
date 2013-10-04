using eStore.DataAccess.Configurations;
using System.Data.Entity;

namespace eStore.DataAccess.Repositories.Ef.BoundedContexts
{
    internal static class CatalogModelsConfigurator
    {
        internal static void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AuthorConfiguration());
            modelBuilder.Configurations.Add(new BookConfiguration());
            modelBuilder.Configurations.Add(new GenreConfiguration());
            modelBuilder.Configurations.Add(new SeriesConfiguration());
        }

    }
}
