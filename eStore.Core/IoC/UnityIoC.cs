using Microsoft.Practices.Unity;
using WrapIoC;

namespace eStore.Core.IoC
{
    internal class UnityIoC : IIoC
    {
        IUnityContainer _Container;

        internal UnityIoC()
        {
            _Container = new UnityContainer();
        }

        #region IIoC

        void IIoC.Register<TIntf, TImpl>(IoCWorkMode mode)
        {
            _Container.RegisterType<TIntf, TImpl>();
        }

        void IIoC.Register<TIntf, TImpl>(string name, IoCWorkMode mode)
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

        object IIoC.Get(System.Type type)
        {
            return _Container.Resolve(type);
        }

        bool IIoC.Release(object obj)
        {
            // is it correct?
            _Container.Teardown(obj);

            return true;
        }

        #endregion
    }
}
