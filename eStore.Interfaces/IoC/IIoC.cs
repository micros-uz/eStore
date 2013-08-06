namespace eStore.Interfaces.IoC
{
    public interface IIoC
    {
        void Register<TIntf, TImpl>() where TImpl : TIntf;
        void Register<TIntf, TImpl>(string name) where TImpl : TIntf;
        T Get<T>();
        T Get<T>(string name);
    }
}
