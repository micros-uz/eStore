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

            HasMany<User>(r => r.Members)
              .WithMany(u => u.Roles)
              .Map(m =>
              {
                  m.ToTable("webpages_UsersInRoles");
                  m.MapLeftKey("UserId");
                  m.MapRightKey("RoleId");
              });
        }
    }
}
