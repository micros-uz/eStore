using System;
using System.Collections.Generic;

namespace eStore.Web.UI.Areas.Social.ViewModels
{
    public class TopicCategoryModel
    {
        public int TopicCategoryId { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public int TopicCount { get; set; }
        public int PostCount { get; set; }
        public DateTime LastPopstDate { get; set; }
        public string LastPostAuthor { get; set; }
    }
}