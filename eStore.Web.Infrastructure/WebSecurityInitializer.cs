using eStore.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebMatrix.WebData;
using WrapIoC;

namespace eStore.Web.Infrastructure
{
    /// <summary>
    /// WebSecurity.Initialized and WebSecurity.InitializeDatabaseConnection are not thread-safe when used together - they create a typical race condition.
    /// 
    /// So we need to have this class.
    /// </summary>
    public class WebSecurityInitializer
    {
        public static readonly WebSecurityInitializer Instance = new WebSecurityInitializer();
        private bool isNotInit = true;
        private readonly object SyncRoot = new object();
        private WebSecurityInitializer() 
        { 
        }

        public void EnsureInitialize()
        {
            if (isNotInit)
            {
                lock (this.SyncRoot)
                {
                    if (isNotInit)
                    {
                        isNotInit = false;

                        WebSecurity.InitializeDatabaseConnection(
                             IoC.Current.Get<IConnectionStringProvider>().ConnectionStringName,
                             "Users",
                             "UserId",
                             "Name", false);
                    }
                }
            }
        }
    }
}
