using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hardware.Buses;
using Hardware.Types;


namespace Hardware.Devices
{
    public abstract class Device: IDevice
    {
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public uint DeviceId { get; protected set; }
        public uint BaseAddress { get; protected set; }
        public virtual uint Size { get; protected set; }
        protected IBus bus;

        public Device(uint deviceId, uint baseAddress, uint size)
        {
            DeviceId = deviceId;
            BaseAddress = baseAddress;
            Size = size;
        }

        public void ConnectBus(IBus bus)
        {
            if (this.bus == null)
                this.bus = bus;
            else
                throw new Exception("BUS ALREADY CONNECTED");
        }

        public void DisconnectBus(IBus bus)
        {
            this.bus = null;
        }

        public Response HandleRequest(Request request)
        {
            if (request.Address >  Size)
                return new Response(
                    StatusCode.ERROR,
                    request.Address,
                    request.Data,
                    $"ERROR REQUEST DOES NOT MATCH DEVICE {Name} WITH ADDRESS 0x{request.Address:X8}"
                );
            return handleRequest(request);
        }

        protected abstract Response handleRequest(Request request);

        public abstract void Step(ulong step_number);

        public abstract void Reset();
    }
}