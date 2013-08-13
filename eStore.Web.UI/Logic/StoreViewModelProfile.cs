using AutoMapper;
using eStore.Domain;
using eStore.Web.UI.Areas.Account.ViewModels;
using eStore.Web.UI.Areas.Store.ViewModels;

namespace eStore.Web.UI.Logic
{
    public class StoreViewModelProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "StoreViewModel";
            }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Genre, GenreModel>();
            Mapper.CreateMap<Book, BookModel>().ForMember(x => x.Author, x => x.MapFrom(w => w.Author.Name));
            Mapper.CreateMap<Book, BookFullModel>().ForMember(x => x.Author, x => x.MapFrom(w => w.Author.Name));
        }
    }
}
