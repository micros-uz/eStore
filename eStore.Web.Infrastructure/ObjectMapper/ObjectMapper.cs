using AutoMapper;

namespace eStore.Web.Infrastructure.ObjectMapper
{
    internal class ObjectMapper : IObjectMapper
    {

        #region IObjectMapper

        TDest IObjectMapper.Map<TSrc, TDest>(TSrc value)
        {
            return Mapper.Map<TSrc, TDest>(value);
        }

        #endregion
    }
}
