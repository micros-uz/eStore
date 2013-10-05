using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace eStore.Web.Infrastructure.Filters.Mvc
{
    public class FilterProvider : IFilterProvider
    {
        #region IFilterProvider

        public IEnumerable<Filter> GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            return FilterProviders.Providers.GetFilters(controllerContext, actionDescriptor);
        }

        #endregion
    }
}
