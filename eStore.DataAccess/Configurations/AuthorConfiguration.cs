using eStore.Domain;
using System.Data.Entity.ModelConfiguration;

namespace eStore.DataAccess.Configurations
{
    internal class AuthorConfiguration : EntityTypeConfiguration<Author>
    {
        public AuthorConfiguration()
        {
            HasKey(x => x.AuthorId);
            Property(x => x.Name).HasMaxLength(200).IsRequired();
        }
    }
}
