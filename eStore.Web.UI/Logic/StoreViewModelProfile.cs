using AutoMapper;
using eStore.Domain;
using eStore.Web.Infrastructure.ObjectMapper;
using eStore.Web.UI.Areas.Store.ViewModels;

namespace eStore.Web.UI.Logic
{
    public class StoreViewModelProfile : IProfile
    {
        public string ProfileName
        {
            get
            {
                return "StoreViewModel";
            }
        }

        public void Configure()
        {
            ObjectMapperConfigurator.Current.CreateMap<Genre, GenreModel>();
            ObjectMapperConfigurator.Current.CreateMap<GenreModel, Genre>();
            ObjectMapperConfigurator.Current.CreateMap<Genre, GenreFullModel>();
            ObjectMapperConfigurator.Current.CreateMap<GenreFullModel, Genre>();
            ObjectMapperConfigurator.Current.CreateMap<AuthorModel, Author>();
            ObjectMapperConfigurator.Current.CreateMap<Author, AuthorModel>();
            ObjectMapperConfigurator.Current.CreateMap<Book, BookModel, string>(x => x.Author, w => w.Author.Name, null);
            ObjectMapperConfigurator.Current.CreateMap<Book, BookModelEx, string>(x => x.Author, w => w.Author.Name);
            ObjectMapperConfigurator.Current.CreateMap<Book, BookFullModel, string>(x => x.Author, w => w.Author.Name);
            ObjectMapperConfigurator.Current.CreateMap<BookFullModel, Book>(x => x.Author, x => x.ImageFile);
            ObjectMapperConfigurator.Current.CreateMap<CartItem, CartItemModel>();


            Mapper.CreateMap<CartItem, CartItemModel>()
                .ForMember(x => x.Price, z => z.MapFrom(x => x.Book.Price))
                .ForMember(x => x.Title, z => z.MapFrom(x => x.Book.Title));
        }
    }
}
