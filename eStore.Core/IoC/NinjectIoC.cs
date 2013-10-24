using Ninject;
using WrapIoC;

namespace eStore.Core.IoC
{
    internal class NinjectIoC : IIoC
    {
        IKernel _Kernel;

        public NinjectIoC()
        {
            var settings = new CustomNinjectSettings(new NinjectSettings());

            _Kernel = new StandardKernel(settings);
        }

        #region IIoC

        void IIoC.Register<TIntf, TImpl>(IoCWorkMode mode)
        {
            var binding = _Kernel.Bind<TIntf>().To<TImpl>();

            if (mode == IoCWorkMode.Singleton)
            {
                binding.InSingletonScope();
            }
        }

        void IIoC.Register<TIntf, TImpl>(string name, IoCWorkMode mode)
        {
            _Kernel.Bind<TIntf>().To<TImpl>().Named(name);
        }

        T IIoC.Get<T>()
        {
            try
            {
                return _Kernel.Get<T>();
            }
            catch (ActivationException ex)
            {
                throw new IoCException(ex.Message);
            }
        }

        T IIoC.Get<T>(string name)
        {
            try
            {
                return _Kernel.Get<T>(name);
            }
            catch (ActivationException ex)
            {
                throw new IoCException(ex.Message);
            }
        }

        object IIoC.Get(System.Type type)
        {
            try
            {
                return _Kernel.Get(type);
            }
            catch (ActivationException ex)
            {
                throw new IoCException(ex.Message);
            }
        }

        bool IIoC.Release(object obj)
        {
            return true;
        }

        #endregion
    }
}
