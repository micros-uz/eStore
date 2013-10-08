using System;

namespace eStore.Web.UI.Areas.Admin.ViewModels
{
    public class LogEntryModel
    {
        public DateTime Date { get; set; }
        public int Severity { get; set; }
        public int AppModule { get; set; }
        public string Data { get; set; }
    }
}