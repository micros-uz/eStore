using Ninject;

namespace eStore.Core.IoC
{
    internal class CustomNinjectSettings : INinjectSettings
    {
        private readonly INinjectSettings _baseSettings;

        internal CustomNinjectSettings(INinjectSettings baseSettings)
        {
            _baseSettings = baseSettings;
        }

        #region INinjectSettings Members

        bool INinjectSettings.ActivationCacheDisabled
        {
            get
            {
                return _baseSettings.ActivationCacheDisabled;
            }
            set
            {
                _baseSettings.ActivationCacheDisabled = value;
            }
        }

        bool INinjectSettings.AllowNullInjection
        {
            get
            {
                return _baseSettings.AllowNullInjection;
            }
            set
            {
                _baseSettings.AllowNullInjection = value;
            }
        }

        System.TimeSpan INinjectSettings.CachePruningInterval
        {
            get { return _baseSettings.CachePruningInterval; }
        }

        System.Func<Ninject.Activation.IContext, object> INinjectSettings.DefaultScopeCallback
        {
            get { return _baseSettings.DefaultScopeCallback; }
        }

        string[] INinjectSettings.ExtensionSearchPatterns
        {
            get { return _baseSettings.ExtensionSearchPatterns; }
        }

        T INinjectSettings.Get<T>(string key, T defaultValue)
        {
            return _baseSettings.Get<T>(key, defaultValue);
        }

        System.Type INinjectSettings.InjectAttribute
        {
            get { return _baseSettings.InjectAttribute; }
        }

        bool INinjectSettings.InjectNonPublic
        {
            get
            {
                return true;
            }
            set
            {
                _baseSettings.InjectNonPublic = value;
            }
        }

        bool INinjectSettings.InjectParentPrivateProperties
        {
            get
            {
                return _baseSettings.InjectParentPrivateProperties;
            }
            set
            {
                _baseSettings.InjectParentPrivateProperties = value;
            }
        }

        bool INinjectSettings.LoadExtensions
        {
            get { return _baseSettings.LoadExtensions; }
        }

        void INinjectSettings.Set(string key, object value)
        {
            _baseSettings.Set(key, value);
        }

        bool INinjectSettings.UseReflectionBasedInjection
        {
            get { return _baseSettings.UseReflectionBasedInjection; }
        }

        #endregion
    }
}
