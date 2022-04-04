using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hardware.Types;
using Hardware.Devices;

namespace Hardware.Buses
{
    public interface IBus
    {
        string Name { get; }
        string Description { get; }
        uint BusId { get; }
        uint Address { get; }
        uint Size { get; }
        List<IDevice> Devices { get; }

        void ConnectDevice(IDevice device);
        void DisconnectDevice(IDevice device);
        Response HandleRequest(Request request);
        void Step(ulong step_number);
    }
}
