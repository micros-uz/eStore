using System.Web.Mvc;

namespace eStore.Web.UI
{
    public static class FiltersConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}