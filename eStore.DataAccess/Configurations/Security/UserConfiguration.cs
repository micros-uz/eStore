﻿using System.Data.Entity.ModelConfiguration;
using eStore.Domain.Security;

namespace eStore.DataAccess.Configurations.Security
{
    internal class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            HasKey(x => x.UserId);
            Property(x => x.Name).HasMaxLength(10).IsRequired();
            Property(x => x.Email).HasMaxLength(20);
        }
    }
}
