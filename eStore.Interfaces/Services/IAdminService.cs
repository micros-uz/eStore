using System;
using System.Collections.Generic;
using eStore.Domain;

namespace eStore.Interfaces.Services
{
    public interface IAdminService
    {
        string DbInit();

        IEnumerable<dynamic> Exec(string query);

        Tuple<IEnumerable<string>, 
            IEnumerable<string>, 
            IEnumerable<string>> GetMigrationsInfo();

        void Migrate(string target, bool isDowngrade);

        IEnumerable<LogEntry> GetLog();
    }
}
