using eStore.Web.Infrastructure.Filters;
using Newtonsoft.Json.Serialization;
using System.Web.Http;
using eStore.Web.Infrastructure.Filters.Http;
using Newtonsoft.Json.Converters;
using WebApiContrib.Formatting.Jsonp;

namespace eStore.Web.UI
{
    public static class GlobalConfig
    {
        public static void CustomizeConfig(HttpConfiguration config)
        {
            // Remove Xml formatters. This means when we visit an endpoint from a browser,
            // Instead of returning Xml, it will return Json.
            // More information from Dave Ward: http://jpapa.me/P4vdx6
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            // Configure json camelCasing per the following post: http://jpapa.me/NqC2HH
            // Here we configure it to write JSON property names with camel casing
            // without changing our server-side data model:
            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver();
            //json.SerializerSettings.Converters.Add(new IsoDateTimeConverter());

            // Add model validation, globally
            config.Filters.Add(new ValidationActionFilter());
            config.Filters.Add(new ExceptionHandlingFilter());

            //Add JSONP support
            // uses WebApiContrib.Formatting.Jsonp that use net40
            var formatter = new JsonpMediaTypeFormatter(json);
            config.Formatters.Insert(0, formatter);

            //config.EnableCors();
        }
    }
}