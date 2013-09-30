using eStore.Domain;
using System.Data.Entity.ModelConfiguration;

namespace eStore.DataAccess.Configurations
{
    internal class BookConfiguration : EntityTypeConfiguration<Book>
    {
        public BookConfiguration()
        {
            HasRequired(x => x.Author)
                .WithMany(z => z.Books)
                .HasForeignKey(w => w.AuthorId);
        }
    }
}
