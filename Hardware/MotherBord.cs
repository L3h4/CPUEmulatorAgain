using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hardware.Buses;
using Hardware.Devices;
using Hardware.Devices.CPU;
using Hardware.Exceptions;
using Hardware.Types;

namespace Hardware
{
    public class MotherBord
    {
        ulong steps;
        CpuBus bus;
        CPU cpu;
        Ram ram;
        BIOS bios;

        public MotherBord()
        {
            bus = new CpuBus(1, 0, 512*128);
            cpu = new CPU(bus, 2);
            ram = new Ram(3, 1024);
            bios = new BIOS(4, 0);
            
            bus.ConnectDevice(bios);
            bus.ConnectDevice(ram);
        }

        public void Step()
        {
            cpu.Step(steps++);
            bus.Step(steps);
        }
    }
}
