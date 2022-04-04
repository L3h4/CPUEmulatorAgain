using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hardware.Types;
using Hardware.Devices;
using Hardware.Buses;
using Hardware.Exceptions;


namespace Hardware.Devices.CPU
{
    public class CPU
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public uint DeviceId { get; private set; }
        private CpuBus bus;

        public Core[] Cores { get; private set; }

        public CPU(CpuBus bus, uint deviceId = 1)
        {
            Name = "CPU";
            Description = "Main CPU";
            DeviceId = deviceId;
            this.bus = bus;
            Cores = new Core[] {
                new Core(1, 0),
                new Core(2, 0),
            };
        }

        public void Reset()
        {
            foreach(Core core in Cores)
                core.Reset();
        }

        public void Step(ulong step_number)
        {
            Console.WriteLine($"step {step_number}");
            Cores[0].Step(step_number);
        }
    }
}
