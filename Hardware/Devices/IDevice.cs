using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hardware.Types;
using Hardware.Buses;


namespace Hardware.Devices
{
    public interface IDevice
    {
        string Name { get; }
        string Description { get; }
        uint DeviceId { get; }
        uint BaseAddress { get; }
        uint Size { get; }

        void ConnectBus(IBus bus);
        void DisconnectBus(IBus bus);

        Response HandleRequest(Request request);
        void Reset();
        void Step(ulong step_number);
    }
}
