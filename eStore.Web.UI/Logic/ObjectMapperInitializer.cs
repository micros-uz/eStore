using eStore.Domain;
using eStore.Web.Infrastructure.ObjectMapper;
using eStore.Web.UI.Areas.Account.ViewModels;
using eStore.Web.UI.Areas.Store.ViewModels;

namespace eStore.Web.UI.Logic
{
    public static class ObjectMapperInitializer
    {
        public static void Init()
        {
            ObjectMapperConfigurator.CreateMap<RegisterModel, User>();

            ObjectMapperConfigurator.CreateMap<Genre, GenreModel>();
            ObjectMapperConfigurator.CreateMap<Book, BookModel, string>(x => x.Author, w => w.Author.Name);
            ObjectMapperConfigurator.CreateMap<Book, BookFullModel, string>(x => x.Author, w => w.Author.Name);

        }
    }
}