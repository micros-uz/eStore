using System;

namespace eStore.Web.Infrastructure.ObjectMapper.Auto
{
    public interface IProfile
    {
        string ProfileName
        {
            get;
        }

        Action ConfigureAction
        {
            get;
        }
    }
}
