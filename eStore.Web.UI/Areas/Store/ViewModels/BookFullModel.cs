namespace eStore.Web.UI.Areas.Store.ViewModels
{
    public class BookFullModel : BookModelEx
    {
        public int AuthorId
        {
            get;
            set;
        }

        public short Year
        {
            get;
            set;
        }

        public short Pages
        {
            get;
            set;
        }

        public string Desc
        {
            get;
            set;
        }

        public string ISBN
        {
            get;
            set;
        }

        public string ImageFilename
        {
            get;
            set;
        }
    }
}