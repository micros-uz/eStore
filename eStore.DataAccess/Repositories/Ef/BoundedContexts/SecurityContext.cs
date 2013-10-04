using eStore.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace eStore.DataAccess.Repositories.Ef.BoundedContexts
{
    class SecurityContext : BaseContext
    {
        public SecurityContext()
            : base()
        {
        }

        public SecurityContext(string connStr)
            : base(connStr)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<OAuthMembership> OAuthMemberships { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Configurations.Add(new RoleConfiguration());
            //modelBuilder.Configurations.Add(new MembershipConfiguration());
            //modelBuilder.Configurations.Add(new OAuthMembershipConfiguration());
            //modelBuilder.Configurations.Add(new UserConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
