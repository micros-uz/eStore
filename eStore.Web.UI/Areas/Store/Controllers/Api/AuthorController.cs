using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using eStore.Core;
using eStore.Domain;
using eStore.Interfaces.Exceptions;
using eStore.Interfaces.Services;
using eStore.Web.Infrastructure.ObjectMapper;
using eStore.Web.UI.Areas.Store.ViewModels;

namespace eStore.Web.UI.Areas.Store.Controllers.Api
{
    public class AuthorController : ApiController
    {
        private readonly IStoreService _service;
        private readonly IObjectMapper _mapper;

        public AuthorController(IStoreService service, IObjectMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public IEnumerable<AuthorModel> Get()
        {
            var authors = _service.GetAuthors();

            return _mapper.Map<IEnumerable<Author>, IEnumerable<AuthorModel>>(authors);
        }

        [HttpPost]
        public void Add(AuthorModel model)
        {
            var author = _mapper.Map<AuthorModel, Author>(model);

            _service.Add(author);
        }
    }
}
