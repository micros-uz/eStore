using Microsoft.Practices.Unity;

namespace eStore.Interfaces.IoC
{
    internal class UnityIoC : IIoC
    {
        IUnityContainer _Container;

        internal UnityIoC()
        {
            _Container = new UnityContainer();
        }

        #region IIoC

        void IIoC.Register<TIntf, TImpl>()
        {
            _Container.RegisterType<TIntf, TImpl>();
        }

        void IIoC.Register<TIntf, TImpl>(string name)
        {
            _Container.RegisterType<TIntf, TImpl>(name);
        }

        T IIoC.Get<T>()
        {
            return _Container.Resolve<T>();
        }

        T IIoC.Get<T>(string name)
        {
            return _Container.Resolve<T>(name);
        }

        #endregion
    }
}
