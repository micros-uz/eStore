using System.Data.Entity;
using System.IO;
using System.Reflection;
using System.Text;

namespace eStore.DataAccess.Repositories.Ef
{
    internal class EfDatabaseInitializer : DropCreateDatabaseIfModelChanges<EStoreDbContext>
    {
        protected override void Seed(EStoreDbContext context)
        {
            StringBuilder script = new StringBuilder();
            var asm = Assembly.GetExecutingAssembly();

            using (var stream = asm.GetManifestResourceStream("eStore.DataAccess.Scripts.script.sql"))
            {
                if (stream != null)
                {
                    string st;
                    var reader = new StreamReader(stream);

                    while ((st = reader.ReadLine()) != null)
                    {
                        if (st.ToUpper().Equals("GO"))
                        {
                            st = ";";
                        }

                        script.AppendLine(st);
                    }

                    context.Database.ExecuteSqlCommand(script.ToString());
                }
            }
        }
    }
}
