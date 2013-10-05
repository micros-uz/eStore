using eStore.Interfaces;
using eStore.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using WrapIoC;

namespace eStore.DataAccess.Repositories.Ef
{
    internal static class EfHelper
    {
        internal static Tuple<IEnumerable<string>, IEnumerable<string>, IEnumerable<string>> GetMigrationsInfo()
        {
            var migrator = new DbMigrator(new Migrations.Configuration());

            return Tuple.Create(migrator.GetDatabaseMigrations(),
                migrator.GetLocalMigrations(), migrator.GetPendingMigrations());
        }

        public static void Migrate(string target, bool isDowngrade)
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
    }
}
