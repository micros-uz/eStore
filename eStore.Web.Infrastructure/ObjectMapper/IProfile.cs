using System;

namespace eStore.Web.Infrastructure.ObjectMapper
{
    public interface IProfile
    {
        string ProfileName
        {
            get;
        }

        void Configure();
    }
}
