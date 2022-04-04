using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Hardware.Types;

namespace Hardware.Devices
{
    public class BIOS : Device
    {

        Data[] memory;

        public BIOS(uint deviceId = 2, uint baseAddress = 0x800B, uint size = 1024): base(deviceId, baseAddress, size)
        {
            memory = new Data[size];
            Name = "BIOS";
            Description = "Basic Input Output System";
            init();
        }
        
        private void init()
        {
            memory[0] = new Data(DataType.UNUMBER, DataSize.QWORD, 0x123456789ABCDEF0);
        }

        public override void Step(ulong step_number)
        {
            
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
                        $"SUCCESSFUL BIOS READ at 0x{BaseAddress:X8} + 0x{request.Address:X8} -> {memory[request.Address]}"
                    );
                    break;
                default:
                    response = new Response(
                        StatusCode.ERROR,
                        request.Address,
                        null,
                        $"BIOS ERROR UNKNOWN OPERATION at 0x{BaseAddress:X8} + 0x{request.Address:X8} <-> {request.Data}"
                    );
                    break;
            }
            return response;
        }

        public override void Reset()
        {
            init();
        }
    }
}
