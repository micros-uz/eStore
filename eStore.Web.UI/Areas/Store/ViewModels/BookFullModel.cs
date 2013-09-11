using System.Web;

namespace eStore.Web.UI.Areas.Store.ViewModels
{
    public class BookFullModel : BookModelEx
    {
        private const int MAX_DESC_Length = 123;
        private const int MAX_TITLE_Length = 40;

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
                return Desc != null ? Desc.Length > MAX_DESC_Length : false;
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

        public string ShortTitle
        {
            get
            {
                return Title.Length <= MAX_TITLE_Length ? Title
                    : Title.Substring(0, MAX_TITLE_Length) + "...";
            }
        }
    }
}