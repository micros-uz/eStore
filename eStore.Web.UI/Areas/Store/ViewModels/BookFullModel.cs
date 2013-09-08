using System.Web;

namespace eStore.Web.UI.Areas.Store.ViewModels
{
    public class BookFullModel : BookModelEx
    {
        private const int MAX_DESC_Length = 123;

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

        public bool IsDescTooLong
        {
            get
            {
                return Desc.Length > MAX_DESC_Length;
            }
        }
        public string ShortDesc
        {
            get
            {
                return IsDescTooLong ? Desc.Substring(0, MAX_DESC_Length) + "..." : Desc;
            }
        }

        public string ISBN
        {
            get;
            set;
        }

        public HttpPostedFileBase Image
        {
            get;
            set;
        }

        public string ImageFile
        {
            get;
            set;
        }
    }
}