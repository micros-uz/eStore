using System.Data.Entity.ModelConfiguration;
using eStore.Domain.Forum;

namespace eStore.DataAccess.Configurations.Social
{
    internal class PostConfiguration : EntityTypeConfiguration<Post>
    {
        public PostConfiguration()
        {
            HasKey(x => x.PostId);
            Property(x => x.Text).HasMaxLength(1024);
            
        }
    }
}
