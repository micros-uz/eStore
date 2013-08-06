
namespace eStore.Interfaces.IoC
{
    public static class IoC
    {
        private static IIoC _Current;

        public static IIoC Current
        {
            get
            {
                return _Current ?? (_Current = new NinjectIoC());
            }

        }
    }
}
