using System;
using System.Linq;
using eStore.DataAccess.Repositories.Ef;
using eStore.DataAccess.Repositories.Ef.BoundedContexts;
using eStore.Domain.Forum;
using eStore.Domain.Security;
using eStore.Interfaces.Data;
using eStore.Interfaces.Repositories;

namespace eStore.DataAccess.Migrations.Initializers
{
    internal class ForumInitializer : IMigrationInitializer
    {
        #region IMigrationInitializer

        void IMigrationInitializer.Run()
        {
            var connStrProvider = new ConnectionStringProvider();

            var forumContext = new ForumContext();

            var topicCategories = forumContext.TopicCategories.ToList();

            var authors = new SecurityContext().Users;

            var topic = topicCategories.First().Topics.First();

            forumContext.Posts.Add(new Post
            {
                Date = DateTime.Parse("2013-09-09"),
                Author = authors.First(),
                Text = "It is crazy.",
                Topic = topic                
            });

            forumContext.SaveChanges();
        }

        #endregion
    }
}
