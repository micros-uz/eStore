using System;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Script.Serialization;
using eStore.Web.UI.Views;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace eStore.Web.UI.Helpers
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString ActionLink(this HtmlHelper htmlHelper, string linkText,
                                       string actionName, string controllerName,
                                       object routeValues, bool noEncode)
        {
            var urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);
            var url = urlHelper.Action(actionName, controllerName, routeValues);

            if (noEncode)
            {
                url = Uri.UnescapeDataString(url);
            }

            var tagBuilder = new TagBuilder("a");

            tagBuilder.MergeAttribute("href", url);
            tagBuilder.InnerHtml = linkText;

            return MvcHtmlString.Create(tagBuilder.ToString(TagRenderMode.Normal));
        }

        public static MvcHtmlString CreateNew<T>(this HtmlHelper<T> helper, object routeValues) where T : class
        {
            MvcHtmlString res = null;

            var view = helper.ViewDataContainer as BaseView<T>;

            if (view != null)
            {
                if (view.IsEditAllowed)
                {
                    res = helper.ActionLink("Create New", "Create", routeValues);
                }
            }

            return res;
        }

        public static MvcHtmlString ToJSON(this HtmlHelper htmlHelper, object data)
        {
            //JavaScriptSerializer serializer = new JavaScriptSerializer();


            //return new MvcHtmlString(serializer.Serialize(data));

            var settings = new JsonSerializerSettings();
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            return new MvcHtmlString(JsonConvert.SerializeObject(data, settings));
        }
    }
}