using System.Data.Entity.ModelConfiguration;
using eStore.Domain.Forum;

namespace eStore.DataAccess.Configurations.Social
{
    internal class TopicConfiguration : EntityTypeConfiguration<Topic>
    {
        public TopicConfiguration()
        {
            HasKey(x => x.TopicId);
            Property(x => x.Theme).HasMaxLength(120);
        }
    }
}
