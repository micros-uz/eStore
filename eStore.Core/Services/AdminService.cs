using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;
using eStore.DataAccess;
using eStore.Interfaces.Services;
using System.IO;
using eStore.Domain;

namespace eStore.Core.Services
{
    internal class AdminService : IAdminService
    {
        private readonly IEnvironmentProvider _envProvider;

        public AdminService(IEnvironmentProvider envProvider)
        {
            _envProvider = envProvider;
        }

        #region IAdminService

        string IAdminService.DbInit()
        {
            try
            {
                return DatabaseHelper.Init().ToString();
            }
            catch (SqlException ex)
            {
                throw new CoreServiceException(ex.Message);
            }
        }

        IEnumerable<dynamic> IAdminService.Exec(string query)
        {
            try
            {
                var lines = query.Split(new string[] { "GO" }, StringSplitOptions.None);

                if (lines.Length > 1)
                    return new List<dynamic>() { DatabaseHelper.Exec2(query) };
                else
                    return DatabaseHelper.Exec(query);
            }
            catch (SqlException ex)
            {
                throw new CoreServiceException(ex.Message);
            }
        }

        Tuple<IEnumerable<string>, IEnumerable<string>, IEnumerable<string>> IAdminService.GetMigrationsInfo()
        {
            return DatabaseHelper.GetMigrationsInfo();
        }
        
        void IAdminService.Migrate(string target, bool isDowngrade)
        {
            DatabaseHelper.Migrate(target, isDowngrade);
            
            CoreBootstraper.NotifyDbMigrated();
        }

        IEnumerable<LogEntry> IAdminService.GetLog()
        {
            using(StreamReader logreader = new StreamReader(Path.Combine(_envProvider.BasePath, @"Log/log.log")))
            {
                string line = logreader.ReadLine();
                
                while(line != null)
                {
                    var e = line.Split('|');

                    yield return new LogEntry
                        {
                            Date = new DateTime(int.Parse(e[0].Substring(0, 4)), 
                               int.Parse( e[0].Substring(5, 2)), 
                               int.Parse(e[0].Substring(8, 2)),
                               int.Parse(e[0].Substring(11, 2)),
                               int.Parse(e[0].Substring(14, 2)),
                               int.Parse(e[0].Substring(17, 2)),
                               int.Parse(e[0].Substring(8, 2))),
                            Severity = 3,
                            AppModule = 1,
                            Data = e[3]
                        };

                    line = logreader.ReadLine();
                }
            }
        }

        #endregion
    }
}
