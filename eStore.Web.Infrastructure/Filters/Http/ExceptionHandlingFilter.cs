using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;
using eStore.Interfaces.Exceptions;
using NLog;

namespace eStore.Web.Infrastructure.Filters.Http
{
    public class ExceptionHandlingFilter : ExceptionFilterAttribute
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public override void OnException(HttpActionExecutedContext context)
        {
            //  1) Business exceptions
            if (context.Exception is CoreServiceException)
            {
                _logger.Error(context.Exception);

                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(context.Exception.Message),
                    ReasonPhrase = "Exception"
                });

            }

            // 2) Critical errors
            _logger.Error(context.Exception);

            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent("An error occurred, please try again or contact the administrator."),
                ReasonPhrase = "Critical Exception"
            });
        }
    }
}
