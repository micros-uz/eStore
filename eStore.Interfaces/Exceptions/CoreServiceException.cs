using System;

namespace eStore.Interfaces.Exceptions
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

        public CoreServiceException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
