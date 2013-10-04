namespace eStore.Interfaces.Repositories
{
    public interface IDbContextFactory
    {
        /// <summary>
        /// Returns bounded context by entity type T
        /// </summary>
        IBaseContext GetContext<T>() where T : class;
    }
}
