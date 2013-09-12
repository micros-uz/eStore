using System;
using System.Linq.Expressions;

namespace eStore.Web.Infrastructure.ObjectMapper
{
    public interface IObjectMapperExpression
    {
        IObjectMapperExpression CreateMap<TSrc, TDest>(params Expression<Func<TDest, object>>[] ignoreDestMembers);
        IObjectMapperExpression CreateMap<TSrc, TDest, TMember>(Expression<Func<TDest, object>> destMember,
            Expression<Func<TSrc, TMember>> srcMember = null,
            Expression<Func<TDest, object>>[] ignoreDestMembers = null,
            params Expression<Func<TSrc, object>>[] ignoreSrcMembers);
    }
}
