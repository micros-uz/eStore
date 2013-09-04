using System;
using System.Linq.Expressions;
using AutoMapper;
using eStore.Web.Infrastructure.ObjectMapper.Auto;

namespace eStore.Web.Infrastructure.ObjectMapper
{
    public static class ObjectMapperConfigurator
    {
        public static void Init(Type type)
        {
            MapperConfiguration.Configure(type);
        }

        public static void CreateMap<TSrc, TDest>(params Expression<Func<TDest, object>>[] ignoreDestMembers)
        {
            var m = Mapper.CreateMap<TSrc, TDest>();

            foreach (var member in ignoreDestMembers)
            {
                m.ForMember(member, x => x.Ignore());
            }
        }

        public static void CreateMap<TSrc, TDest, TMember>(Expression<Func<TDest, object>> destMember,
            Expression<Func<TSrc, TMember>> srcMember = null,
            Expression<Func<TDest, object>>[] ignoreDestMembers = null,
            params Expression<Func<TSrc, object>>[] ignoreSrcMembers)
        {
            IMappingExpression<TSrc, TDest> m;

            if (srcMember != null)
            {
                m = Mapper.CreateMap<TSrc, TDest>().ForMember(destMember, x => x.MapFrom(srcMember));
            }
            else
            {
                m = Mapper.CreateMap<TSrc, TDest>().ForMember(destMember, x => x.Ignore());
            }

            if (ignoreDestMembers != null)
            {
                foreach (var member in ignoreDestMembers)
                {
                    m.ForMember(member, x => x.Ignore());
                }
            }

            foreach (var member in ignoreSrcMembers)
            {
                m.ForSourceMember(member, x => x.Ignore());
            }
        }
    }
}
