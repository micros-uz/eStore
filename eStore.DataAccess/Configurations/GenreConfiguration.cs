using eStore.Domain;
using System.Data.Entity.ModelConfiguration;

namespace eStore.DataAccess.Configurations
{
    internal class GenreConfiguration : EntityTypeConfiguration<Genre>
    {
        public GenreConfiguration()
        {
            HasKey(x => x.GenreId);
            Property(x => x.Title).HasMaxLength(30).IsRequired();
            Property(x => x.Desc).HasMaxLength(200);
        }
    }
}
