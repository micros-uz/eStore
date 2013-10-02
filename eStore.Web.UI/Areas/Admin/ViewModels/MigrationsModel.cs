using System.Collections.Generic;
namespace eStore.Web.UI.Areas.Admin.ViewModels
{
    public class MigrationsModel
    {
        public IEnumerable<string> Database { get; set; }
        public IEnumerable<string> Local { get; set; }
        public IEnumerable<string> Pending { get; set; }
    }
}