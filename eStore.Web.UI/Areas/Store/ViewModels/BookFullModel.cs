namespace eStore.Web.UI.Areas.Store.ViewModels
{
    public class BookFullModel : BookModel
    {
        public int GenreId { get; set; }

        public short Year { get; set; }
        public short Pages { get; set; }
        public string Desc { get; set; }
    }
}