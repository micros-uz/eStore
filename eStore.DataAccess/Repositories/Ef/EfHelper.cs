using eStore.Interfaces.Data;
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

                    IoC.Current.Get<IPredefinedDataManager>().Run(target);
                }
                else
                {
                    if (isDowngrade)
                    {
                        migrator.Update("0");
                    }
                    else
                    {
                        var pendings = migrator.GetPendingMigrations();

                        foreach (var migrName in pendings)
                        {
                            migrator.Update(migrName);
                            IoC.Current.Get<IPredefinedDataManager>().Run(migrName);
                        }                        
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
