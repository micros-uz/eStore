using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using eStore.DataAccess;
using eStore.Interfaces.Services;
using System.IO;

namespace eStore.Core.Services
{
    internal class AdminService : IAdminService
    {
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

        #endregion
    }
}
