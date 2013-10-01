using eStore.Domain;
using System.Data.Entity.ModelConfiguration;

namespace eStore.DataAccess.Configurations.Security
{
    internal class OAuthMembershipConfiguration : EntityTypeConfiguration<OAuthMembership>
    {
        public OAuthMembershipConfiguration()
        {
            ToTable("webpages_OAuthMembership");
            HasKey(x => x.Provider);
            HasKey(x => x.ProviderUserId);
            Property(x => x.UserId).IsRequired();

            Property(x => x.Provider).HasMaxLength(30).HasColumnOrder(0);
            Property(x => x.ProviderUserId).HasMaxLength(100).HasColumnOrder(1);
        }
    }
}
