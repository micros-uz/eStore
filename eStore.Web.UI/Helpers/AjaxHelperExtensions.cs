using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace eStore.Web.UI.Helpers
{
    public static class AjaxHelperExtensions
    {
        public static MvcHtmlString BS3ImageActionLink(this AjaxHelper helper, string glyphType, string actionName, string controllerName, object routeValues, AjaxOptions ajaxOptions)
        {
            var builder = new TagBuilder("span");
            builder.MergeAttribute("class", string.Format("glyphicon glyphicon-{0}", glyphType));

            var link = helper.ActionLink("[fefe]", actionName, controllerName, routeValues, ajaxOptions);
            return new MvcHtmlString(link.ToHtmlString().Replace("[fefe]", builder.ToString(TagRenderMode.SelfClosing)));
        }
    }
}