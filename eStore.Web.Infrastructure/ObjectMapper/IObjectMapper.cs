namespace eStore.Web.Infrastructure.ObjectMapper
{
    public interface IObjectMapper
    {
        TDest Map<TSrc, TDest>(TSrc value);
    }
}
