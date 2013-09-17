namespace eStore.Web.UI.Areas.Admin.ViewModels
{
    public class FilterParams
    {
        public int? Role { get; set; }

        public FilterParams()
        {
            ShowManagers = true;
            ShowAdmins = true;
        }

        //public int? AgeFrom { get; set; }
        //public int? AgeTo { get; set; }
        public bool ShowAdmins { get; set; }
        public bool ShowManagers { get; set; }
    }
}