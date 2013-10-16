using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;
using eStore.DataAccess;
using eStore.Interfaces.Services;
using System.IO;
using eStore.Domain.Security;
using eStore.Domain.Admin;
using NLog;
using eStore.Interfaces.Exceptions;

namespace eStore.Core.Services
{
    internal class AdminService : IAdminService
    {
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();
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
                _logger.Error(ex.Message);
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
                _logger.Error(ex.Message);
                throw new CoreServiceException(ex.Message);
            }
        }

        Tuple<IEnumerable<string>, IEnumerable<string>, IEnumerable<string>> IAdminService.GetMigrationsInfo()
        {
            try
            {
                return DatabaseHelper.GetMigrationsInfo();

            }
            catch (DataAccessException ex)
            {
                throw new CoreServiceException(ex.Message, ex);
            }
        }
        
        void IAdminService.Migrate(string target, bool isDowngrade)
        {
            try
            {
                DatabaseHelper.Migrate(target, isDowngrade);
            }
            catch (DataAccessException ex)
            {
                throw new CoreServiceException(ex.Message, ex);
            }            

            CoreBootstraper.NotifyDbMigrated();
        }

        IEnumerable<LogEntry> IAdminService.GetLog()
        {
            using(var logreader = new StreamReader(Path.Combine(_envProvider.BasePath, @"Log/log.log")))
            {
                string line = logreader.ReadLine();
                
                while(line != null)
                {
                    var e = line.Split('|');

                    if (e.Length == 4)
                    {
                        yield return new LogEntry
                            {
                                Date = DateTime.Parse(e[0]),
                                Severity = 3,
                                AppModule = 1,
                                Data = e[3]
                            };
                    }

                    line = logreader.ReadLine();
                }
            }
        }

        #endregion
    }
}
