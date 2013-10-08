using System.Collections.Generic;

namespace eStore.Web.UI.Areas.Admin.ViewModels
{
    public class LogModel
    {
        public IEnumerable<string> Severities { get; set; }
        public IEnumerable<string> AppModules { get; set; }
        public IEnumerable<LogEntryModel> Entries { get; set; }
    }
}