using eStore.Interfaces.Services;
using System.Collections.Generic;
using System.Net;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using eStore.Web.UI.Areas.Store.ViewModels;
using eStore.Web.Infrastructure.ObjectMapper;
using eStore.Domain;
using eStore.Core;
using eStore.Interfaces.Exceptions;
using eStore.Domain.Store;

namespace eStore.Web.UI.Areas.Store.Controllers.Api
{
    public class GenreController : ApiController
    {
        private readonly IStoreService _service;
        private readonly IObjectMapper _mapper;
        public GenreController(IStoreService service, IObjectMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public IEnumerable<GenreModel> Get()
        {
            var genres = _service.GetGenres();

            return _mapper.Map<IEnumerable<Genre>, IEnumerable<GenreModel>>(genres);
        }

        [HttpPost]
        public HttpResponseMessage Add(GenreModel model)
        {
            var genre = _mapper.Map<GenreModel, Genre>(model);

            try
            {
                _service.Add(genre);
            }
            catch(CoreServiceException ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
