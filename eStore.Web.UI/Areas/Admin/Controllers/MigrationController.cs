using eStore.Interfaces.Services;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace eStore.Web.UI.Areas.Admin.Controllers
{
    public class MigrationData
    {
        public string Target { get; set; }
        public bool IsDowngrade { get; set; }
    }

    //[Authorize]
    public class MigrationController : ApiController
    {
        private readonly IAdminService _service;
        public MigrationController(IAdminService service)
        {
            _service = service;
        }

        //[AllowAnonymous]
        [HttpPost]
        public HttpResponseMessage UpdateTo(MigrationData data)
        {
            _service.Migrate(data.Target, data.IsDowngrade);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
