using System;

namespace eStore.Core
{
    public class CoreServiceException : Exception
    {
        public CoreServiceException()
            : base()
        {

        }

        public CoreServiceException(string message)
            : base(message)
        {

        }
    }
}
