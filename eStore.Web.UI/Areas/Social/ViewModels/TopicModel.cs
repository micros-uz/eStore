using System;

namespace eStore.Web.UI.Areas.Social.ViewModels
{
    public class TopicModel
    {
        public int TopicId { get; set; }
        public string Theme { get; set; }

        public int PostCount { get; set; }
        public int ViewsCount { get; set; }
        public DateTime LastPostDate { get; set; }
        public string LastPostAuthor { get; set; }
    }
}