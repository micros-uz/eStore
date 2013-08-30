using eStore.Domain;
using eStore.Web.Infrastructure.ObjectMapper;
using eStore.Web.UI.Areas.Admin.ViewModels;

namespace eStore.Web.UI.Logic
{
    public class AdminViewModelProfile : IProfile
    {
        public string ProfileName
        {
            get
            {
                return "AdminViewModel";
            }
        }

        public void Configure()
        {
            ObjectMapperConfigurator.CreateMap<UserModel, User>();
            ObjectMapperConfigurator.CreateMap<User, UserModel>();
        }
    }
}