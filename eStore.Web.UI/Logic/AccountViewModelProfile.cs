using AutoMapper;
using eStore.Domain;
using eStore.Web.Infrastructure.ObjectMapper;
using eStore.Web.UI.Areas.Account.ViewModels;

namespace eStore.Web.UI.Logic
{
    public class AccountViewModelProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "AccountViewModel";
            }
        }

        protected override void Configure()
        {
            ObjectMapperConfigurator.CreateMap<RegisterModel, User>();
        }
    }
}