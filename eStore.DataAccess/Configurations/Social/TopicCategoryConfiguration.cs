using System.Data.Entity.ModelConfiguration;
using eStore.Domain.Forum;

namespace eStore.DataAccess.Configurations.Social
{
    internal class TopicCategoryConfiguration : EntityTypeConfiguration<TopicCategory>
    {
        public TopicCategoryConfiguration()
        {
            HasKey(x => x.TopicCategoryId);
            Property(x => x.Title).HasMaxLength(80);
            Property(x => x.Desc).HasMaxLength(150);
            HasMany(x => x.Topics).WithRequired(x => x.Category).WillCascadeOnDelete(false);
        }
    }
}
