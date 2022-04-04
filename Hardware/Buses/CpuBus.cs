using Hardware.Devices;
using Hardware.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hardware.Buses
{

    public class CpuBus : Bus
    {

        public CpuBus(uint busId = 0x1, uint address = 0x0, uint size = 512 * 64): base(busId, address, size)
        {
            Name = "Main CPU BUS";
            Description = "Main CPU BUS";
        }


    }
}
