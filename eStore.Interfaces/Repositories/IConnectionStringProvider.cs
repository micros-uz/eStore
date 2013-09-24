namespace eStore.Interfaces.Repositories
{
    public interface IConnectionStringProvider
    {
        string ConnectionString
        {
            get;
        }

        string ConnectionStringName
        {
            get;
        }
    }
}
