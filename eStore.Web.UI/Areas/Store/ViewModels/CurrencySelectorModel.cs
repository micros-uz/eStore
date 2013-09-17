using System.Collections.Generic;

namespace eStore.Web.UI.Areas.Store.ViewModels
{
    public class CurrencyModel
    {
        public string Name { get; set; }

        // codehint: sm-add
        public string ISOCode { get; set; }
        public string Symbol { get; set; }
    }

    public class CurrencySelectorModel
    {
        public IEnumerable<CurrencyModel> Currencies { get; set; }
    }
}