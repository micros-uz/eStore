namespace eStore.Interfaces.Data
{
    public interface IPredefinedDataManager
    {
        void Register(string targetMigration, IMigrationInitializer initializer);
        void Run(string targetMigration);
    }
}
