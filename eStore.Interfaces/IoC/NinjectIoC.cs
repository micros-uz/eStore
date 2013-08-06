﻿using Ninject;

namespace eStore.Interfaces.IoC
{
    internal class NinjectIoC : IIoC
    {
        IKernel _Kernel;

        public NinjectIoC()
        {
            _Kernel = new StandardKernel();
        }

        #region IIoC

        void IIoC.Register<TIntf, TImpl>()
        {
            _Kernel.Bind<TIntf>().To<TImpl>();
        }

        void IIoC.Register<TIntf, TImpl>(string name)
        {
            _Kernel.Bind<TIntf>().To<TImpl>().Named(name);
        }

        T IIoC.Get<T>()
        {
            return _Kernel.Get<T>();
        }

        T IIoC.Get<T>(string name)
        {
            return _Kernel.Get<T>(name);
        }

        #endregion
    }
}
