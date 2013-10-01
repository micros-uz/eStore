using eStore.Domain;
using System.Data.Entity.ModelConfiguration;

namespace eStore.DataAccess.Configurations
{
    internal class BookConfiguration : EntityTypeConfiguration<Book>
    {
        public BookConfiguration()
        {
            HasKey(x => x.BookId);
            HasRequired(x => x.Author)
                .WithMany(z => z.Books)
                .HasForeignKey(w => w.AuthorId)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.Genre)
                .WithMany()
                .WillCascadeOnDelete(false);

            Property(x => x.Title).HasMaxLength(200);
            Property(x => x.ISBN).HasMaxLength(20);
        }
    }
}
