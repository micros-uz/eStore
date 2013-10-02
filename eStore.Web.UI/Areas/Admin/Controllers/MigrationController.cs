using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace eStore.Web.UI.Areas.Admin.Controllers
{
    //[Authorize]
    public class MigrationController : ApiController
    {
        //[AllowAnonymous]
        [HttpPost]
        public HttpResponseMessage UpdateTo(string target, bool isDowngrade)
        {
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
