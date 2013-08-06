using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eStore.Web.Areas.Admin.ViewModels
{
    public class GridDataModel
    {
        public IEnumerable<string> Headers { get; set; }
        public IEnumerable<string> Columns { get; set; }
        public IEnumerable<dynamic> Data { get; set; }
    }
}