using System.Linq;
using AutoMapper;
using System;

namespace eStore.Web.Infrastructure.ObjectMapper.Auto
{
    public static class MapperConfiguration
    {
        public static void Configure(Type type)
        {
            // workaround for the AutoMapper.Net4 issue
            // it is not copied to the main bin directory
            var dr = new AutoMapper.Mappers.DataReaderMapper();

            Mapper.Initialize(x => GetConfiguration(Mapper.Configuration, type));
        }

        private static void GetConfiguration(IConfiguration configuration, Type type)
        {
            var profiles = type.Assembly.GetTypes().Where(x => typeof(IProfile).IsAssignableFrom(x));

            foreach (var profile in profiles)
            {
                configuration.AddProfile(new ConfigProfile(Activator.CreateInstance(profile) as IProfile));
            }
        }
    }
}