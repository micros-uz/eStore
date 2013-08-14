using AutoMapper;

namespace eStore.Web.Infrastructure.ObjectMapper.Auto
{
    internal class ConfigProfile : Profile
    {
        private IProfile _profile;
        public ConfigProfile(IProfile profile)
        {
            _profile = profile;
        }

        public override string ProfileName
        {
            get
            {
                return _profile.ProfileName; ;
            }
        }

        protected override void Configure()
        {
            _profile.Configure();
        }
    }
}
