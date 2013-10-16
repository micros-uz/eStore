using System;

namespace eStore.Domain.Admin
{
    public class LogEntry
    {
        public DateTime Date { get; set; }
        public int Severity { get; set; }
        public int AppModule { get; set; }
        public string Data { get; set; }
    }
}
