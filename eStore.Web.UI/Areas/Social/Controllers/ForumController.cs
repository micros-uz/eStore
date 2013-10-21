using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eStore.Domain.Forum;
using eStore.Interfaces.Services;
using eStore.Web.Infrastructure.Filters.Mvc;
using eStore.Web.Infrastructure.ObjectMapper;
using eStore.Web.UI.Areas.Social.ViewModels;
using eStore.Web.UI.Logic;

namespace eStore.Web.UI.Areas.Social.Controllers
{
    [DbVersion(3)]
    public class ForumController : BaseDisposeController
    {
        private readonly IForumService _service;
        private readonly IObjectMapper _mapper;

        public ForumController(IForumService service, IObjectMapper mapper) 
            : base(service)
        {
            _service = service;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var categories = _service.GetTopicCategories().ToList();
            var models = new List<TopicCategoryModel>();

            foreach (var item in categories)
            {
                var model = _mapper.Map<TopicCategory, TopicCategoryModel>(item);
                model.TopicCount = item.Topics.Count; //todo - not optimal query ???
                model.PostCount = item.Topics.Sum(x => x.Posts.Count());
                models.Add(model);
            }

            return View(models);
        }

        public ActionResult Topics(int id)
        {
            var topics = _service.GetTopics(id);

            var models = new List<TopicModel>();

            return CheckResource(topics, () =>
            {
                foreach (var topic in topics)
	            {
                    var model = _mapper.Map<Topic, TopicModel>(topic);

                    model.PostCount = topic.Posts.Count();

                    models.Add(model);
	 
	            }

                return View(models);
            });
        }

        public ActionResult Topic(int id)
        {
            var topic = _service.GetTopic(id);

            var topicModel = _mapper.Map<Topic, TopicModel>(topic);

            return CheckResource(topic, () =>
                {
                    return View(topicModel);
                });
        }
    }
}
