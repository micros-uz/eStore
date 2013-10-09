using eStore.Interfaces;
using eStore.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using WrapIoC;
using System.Data.Entity.Migrations.Infrastructure;

namespace eStore.DataAccess.Repositories.Ef
{
    internal static class EfHelper
    {
        internal static Tuple<IEnumerable<string>, IEnumerable<string>, IEnumerable<string>> GetMigrationsInfo()
        {
            try
            {
                var migrator = new DbMigrator(new Migrations.Configuration());

                return Tuple.Create(migrator.GetDatabaseMigrations(),
                    migrator.GetLocalMigrations(), migrator.GetPendingMigrations());
            }
            catch (MigrationsException ex)
            {
                throw new DataAccessException("Failed to retreive migrations information", ex);
            }
        }

        public static void Migrate(string target, bool isDowngrade)
        {

            try
            {
                var migrator = new DbMigrator(new Migrations.Configuration());

                if (!string.IsNullOrEmpty(target))
                {
                    migrator.Update(target);
                }
                else
                {
                    if (isDowngrade)
                    {
                        migrator.Update("0");
                    }
                    else
                    {
                        migrator.Update();
                    }
                }
            }
            catch (MigrationsException ex)
            {
                throw new DataAccessException("Migration failed", ex);
            }
        }
    }
}
