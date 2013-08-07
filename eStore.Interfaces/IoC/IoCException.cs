using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eStore.Interfaces.IoC
{
    public class IoCException : Exception
    {
        public IoCException(string message)
            :base(message)
        {

        }
    }
}
