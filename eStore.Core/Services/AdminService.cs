using System.Data.SqlClient;
using eStore.DataAccess;
using eStore.Interfaces.Services;

namespace eStore.Core.Services
{
    internal class AdminService : IAdminService
    {
        #region IAdminService

        string IAdminService.DbInit()
        {
            try
            {
                return "COMMENTED";//DatabaseInitializer.Init().ToString();
            }
            catch (SqlException ex)
            {
                throw new CoreServiceException(ex.Message);
            }
        }

        #endregion
    }
}
