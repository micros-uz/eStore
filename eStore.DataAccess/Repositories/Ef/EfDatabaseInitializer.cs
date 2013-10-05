using System.Data.Entity;
using System.IO;
using System.Reflection;
using System.Text;
using eStore.DataAccess.Migrations;
using eStore.DataAccess.Repositories.Ef.BoundedContexts;

namespace eStore.DataAccess.Repositories.Ef
{
    internal class EfDatabaseInitializer : MigrateDatabaseToLatestVersion<CommonContext, Configuration>
    {
        /*
        protected void Seed(CommonContext context)
        {
            StringBuilder script = new StringBuilder();
            var asm = Assembly.GetExecutingAssembly();

            using (var stream = asm.GetManifestResourceStream("eStore.DataAccess.Scripts.Data.sql"))
            {
                if (stream != null)
                {
                    string st;
                    var reader = new StreamReader(stream);

                    while ((st = reader.ReadLine()) != null)
                    {
                        if (st.Replace("\t", " ").ToUpper().Equals("GO"))
                        {
                            st = ";";
                        }

                        script.AppendLine(st);
                    }

                    context.Database.ExecuteSqlCommand(script.ToString());
                }
            }
        }
       * */
    }
}
