using AutoMapper;
using System;
using System.Linq.Expressions;

namespace eStore.Web.Infrastructure.ObjectMapper
{
    public static class ObjectMapperConfigurator
    {
        public static void CreateMap<TSrc, TDest>()
        {
            Mapper.CreateMap<TSrc, TDest>();
        }

        public static void CreateMap<TSrc, TDest, TMember>(Expression<Func<TDest, object>> destMember, 
            Expression<Func<TSrc, TMember>> srcMember)
        {
            Mapper.CreateMap<TSrc, TDest>().ForMember(destMember, x => x.MapFrom(srcMember));
        }
    }
}
