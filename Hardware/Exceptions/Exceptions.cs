using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hardware.Exceptions
{
    public class ReadException: Exception
    {
        public ReadException(string message): base(message) { }
    }
    public class WriteException : Exception
    {
        public WriteException(string message) : base(message) { }
    }
    public class ConnectException : Exception
    {
        public ConnectException(string message) : base(message) { }
    }
}
