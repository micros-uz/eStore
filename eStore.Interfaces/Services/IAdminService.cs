using System.Collections.Generic;

namespace eStore.Interfaces.Services
{
    public interface IAdminService
    {
        string DbInit();

        IEnumerable<dynamic> Exec(string query);
    }
}
