using eStore.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace eStore.DataAccess.Configurations.Security
{
    internal class MembershipConfiguration : EntityTypeConfiguration<Membership>
    {
        public MembershipConfiguration()
        {
            ToTable("webpages_Membership");
            HasKey(x => x.UserId);
            Property(x => x.UserId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.ConfirmationToken).HasMaxLength(128);
            Property(x => x.Password).HasMaxLength(128).IsRequired();
            Property(x => x.PasswordSalt).HasMaxLength(128).IsRequired();
            Property(x => x.PasswordVerificationToken).HasMaxLength(128);
            
            HasMany<Role>(r => r.Roles)
              .WithMany(u => u.Members)
              .Map(m =>
              {
                  m.ToTable("webpages_UsersInRoles");
                  m.MapLeftKey("UserId");
                  m.MapRightKey("RoleId");
              });
        }
    }
}
