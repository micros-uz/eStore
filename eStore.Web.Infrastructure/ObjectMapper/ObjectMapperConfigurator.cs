using AutoMapper;
using eStore.Web.Infrastructure.ObjectMapper.Auto;
using System;
using System.Linq.Expressions;

namespace eStore.Web.Infrastructure.ObjectMapper
{
    public static class ObjectMapperConfigurator
    {
        public static void Init(Type type)
        {
            MapperConfiguration.Configure(type);
        }
        public static void CreateMap<TSrc, TDest>(Expression<Func<TDest, object>> ignoreDestMember = null)
        {
            var m = Mapper.CreateMap<TSrc, TDest>();

            if (ignoreDestMember != null)
            {
                m.ForMember(ignoreDestMember, x => x.Ignore());
            }
        }

        public static void CreateMap<TSrc, TDest, TMember>(Expression<Func<TDest, object>> destMember,
            Expression<Func<TSrc, TMember>> srcMember = null)
        {
            if (srcMember != null)
            {
                Mapper.CreateMap<TSrc, TDest>().ForMember(destMember, x => x.MapFrom(srcMember));
            }
            else
            {
                Mapper.CreateMap<TSrc, TDest>().ForMember(destMember, x => x.Ignore());
            }
        }
    }
}
