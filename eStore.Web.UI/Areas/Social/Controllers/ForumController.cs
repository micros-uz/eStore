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
    [DbVersion(2)]
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
            var categories = _service.GetTopicCategories();

            var model = _mapper.Map<IEnumerable<TopicCategory>, IEnumerable<TopicCategoryModel>>(categories);

            foreach (var item in categories)
            {

            }

            return View(model);
        }

    }
}
