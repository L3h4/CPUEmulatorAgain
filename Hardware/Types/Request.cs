using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hardware.Types
{
    public struct Request
    {
        public uint Address;
        public uint Count;
        public RequestMethod Method;
        public RequestType Type;
        public Privileges ContextPrivileges;
        public Data Data;

        public Request(uint address, RequestMethod method, RequestType type, Data data, Privileges contextPrivileges, uint count = 0)
        {
            Address = address;
            Count = count;
            Method = method;
            Type = type;
            ContextPrivileges = contextPrivileges;
            Data = data;
        }
    }
}
