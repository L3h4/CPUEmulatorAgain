using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hardware.Devices.CPU
{
    public class Core
    {
        public uint Id { get; private set; }
        public uint StartAddress { get; private set; }
        public RegisterFile Registers { get; private set; }

        public Core(uint id, uint startAddress)
        {
            StartAddress = startAddress;
            Id = id;
            Registers = new RegisterFile((byte)id);
        }

        public void Reset()
        {
            Registers.A.Data64 = 0;
            Registers.B.Data64 = 0;
            Registers.C.Data64 = 0;
            Registers.D.Data64 = 0;
            Registers.E.Data64 = 0;
            Registers.F.Data64 = 0;

            Registers.IP.Data64 = StartAddress;
            Registers.SP.Data64 = 0;

            Registers.IDT.Data64 = 0;
            Registers.GDT.Data64 = 0;

            Registers.STATUS.Data64 = 0;

            Registers.SEGMENTS1.Data64 = 0;
            Registers.SEGMENTS2.Data64 = 0;
            Registers.SEGMENTS3.Data64 = 0;
        }

        public void Step(ulong step_number)
        {

        }
    }
}
