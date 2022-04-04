using Hardware.Buses;
using Hardware.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hardware.Devices
{
    public class Ram: Device
    {
        
        public override uint Size => (uint)memory.Length;
        private Data[] memory;

        public Ram(uint deviceId=0x1, uint baseAddress=0xA, uint size = 512 * 64) : base(deviceId, baseAddress, size)
        {
            memory = new Data[size];
        }

       
        protected override Response handleRequest(Request request)
        {
            Response response;
            switch (request.Method)
            {
                case RequestMethod.READ:
                    response = new Response(
                        StatusCode.OK,
                        request.Address,
                        memory[request.Address],
                        $"SUCCESSFUL RAM READ at 0x{BaseAddress:X8} + 0x{request.Address:X8} -> {memory[request.Address]}"
                    );
                    break;
                case RequestMethod.WRITE:
                    memory[request.Address] = request.Data;
                    response = new Response(
                        StatusCode.OK,
                        request.Address,
                        request.Data,
                        $"SUCCESSFUL RAM WRITE at 0x{BaseAddress:X8} + 0x{request.Address:X8} <- {request.Data}"
                    );
                    break;
                default:
                    response = new Response(
                        StatusCode.ERROR,
                        request.Address,
                        request.Data,
                        $"RAM ERROR UNKNOWN OPERATION 0x{BaseAddress:X8} + at 0x{request.Address:X8} <-> {request.Data}"
                    );
                    break;
            }
            return response;
        }

        public override void Step(ulong step_number)
        {
            
        }

        public override void Reset()
        {
            memory = new Data[Size];
        }
    }
}
