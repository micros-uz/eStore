
namespace eStore.Web.UI.Areas.Store.ViewModels
{
    public class AddEditBookModel
    {
        public BookFullModel Book
        {
            get;
            set;
        }

        public string Action
        {
            get;
            set;
        }

        public string OldImageFile
        {
            get;
            set;
        }

        public bool IsImageChanged
        {
            get;
            set;
        }
    }
}