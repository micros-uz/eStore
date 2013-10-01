using eStore.Domain;
using System.Data.Entity.ModelConfiguration;

namespace eStore.DataAccess.Configurations.Security
{
    internal class RoleConfiguration : EntityTypeConfiguration<Role>
    {
        public RoleConfiguration()
        {
            ToTable("webpages_Roles");

            HasKey(x => x.RoleId);
            Property(x => x.Name).HasColumnName("RoleName").HasMaxLength(256).IsRequired();
        }
    }
}
