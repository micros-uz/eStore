namespace eStore.Web.UI.Areas.Admin.ViewModels
{
    public class ExecSqlModel
    {
        public string Server { get; set; }
        public string DataBase { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Query { get; set; }
        public string Result { get; set; }
    }
}