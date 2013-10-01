using System;

namespace eStore.DataAccess.Migrations
{
    internal static class SecurityDropHelper
    {
        internal static void DropTables(Action<string> dropAction)
        {
            dropAction("dbo.webpages_Membership");
            dropAction("dbo.webpages_OAuthMembership");
            dropAction("dbo.webpages_UsersInRoles");
            dropAction("dbo.webpages_Roles");
        }
    }
}
