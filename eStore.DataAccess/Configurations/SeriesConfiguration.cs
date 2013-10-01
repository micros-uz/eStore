using eStore.Domain;
using System.Data.Entity.ModelConfiguration;

namespace eStore.DataAccess.Configurations
{
    internal class SeriesConfiguration : EntityTypeConfiguration<Series>
    {
        public SeriesConfiguration()
        {
            HasKey(x => x.SeriesId);
            Property(x => x.Title).HasMaxLength(30).IsRequired();
            Property(x => x.Desc).HasMaxLength(200);
        }
    }
}
