using eStore.Web.UI.Views;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace eStore.Web.UI.Helpers
{
    public static class HtmlHelperExtensions
    {
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
    }
}