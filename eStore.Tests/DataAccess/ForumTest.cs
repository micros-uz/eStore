using System;
using System.Collections.Generic;
using System.Linq;
using eStore.DataAccess.Repositories.Ef.BoundedContexts;
using eStore.Domain.Forum;
using eStore.Domain.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eStore.Tests.DataAccess
{
    [TestClass]
    public class ForumTest
    {
        [TestMethod]
        public void CreateNewTopicInNewCategory()
        {
            var ctx = ContextHelper.GetForumContext();

            if (!ctx.Database.Exists())
            {
                ctx.Database.Initialize(true);
            }

            var newCat = new TopicCategory
                {
                    Title = "New Cat",
                    Desc = "Test Cat",
                };

            var newTopic = new Topic
            {
                Theme = "New Theme",
                Category = newCat                
            };

            var newPost = new Post
            {
                Author = new User
                {
                    Name = "TestUser"
                },
                Topic = newTopic,
                Text = "ExamplePost",
                Date = DateTime.Now

            };

            newTopic.Posts.Add(newPost);
            newCat.Topics.Add(newTopic);

            ctx.TopicCategories.Add(newCat);
            ctx.SaveChanges();

            var cat = ContextHelper.GetForumContext().TopicCategories.FirstOrDefault(x => x.Title == "New Cat");
            var topic = cat.Topics.FirstOrDefault(x => x.Theme == "New Theme");
            var post = topic.Posts.First();

            Assert.IsNotNull(cat);
            Assert.IsNotNull(topic);
            Assert.IsNotNull(post);
        }
    }
}
