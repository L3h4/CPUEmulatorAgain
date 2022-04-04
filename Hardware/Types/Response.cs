using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hardware.Types
{
    public enum StatusCode
    {
        OK,
        OK_MANY,
        ERROR,
        PRIVILEGES_ERROR,
    }
    public struct Response
    {
        public StatusCode Code { get; set; }
        public string Message { get; set; } // Debug only
        public uint Address { get; set; }
        public Data Data { get; set; }
        

        public Response(StatusCode code, uint address, Data data, string message = "")
        {
            Code = code;
            Message = message;
            Address = address;
            Data = data;
        }
    }
}
