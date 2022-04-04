using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hardware.Devices;
using Hardware.Types;

namespace Hardware.Buses
{
    public abstract class Bus : IBus
    {
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public uint BusId { get; protected set; }
        public uint Address { get; protected set; }
        public uint Size { get; protected set; }
        public List<IDevice> Devices { get; protected set; }

        public Bus(uint busId, uint address, uint size)
        {
            if (size == 0)
            {
                throw new ArgumentException("Size of Ram must be > 0");
            }
            Devices = new List<IDevice>();
            BusId = busId;
            Address = address;
            Size = size;
            Name = "Abstract Bus";
            Description = "Abstract Bus";

        }

        public void ConnectDevice(IDevice device)
        {
            if (Devices.Contains(device))
                throw new Exception("DEVICE ALREADY CONNECTED");

            foreach (IDevice d in Devices)
            {
                if (device.BaseAddress >= d.BaseAddress &&
                   device.BaseAddress < d.BaseAddress + d.Size ||
                   device.BaseAddress + device.Size >= d.BaseAddress &&
                   device.BaseAddress + device.Size <= d.BaseAddress + d.Size)
                    throw new Exception("ADDRESS SPACE ALREADY OCCUPIED");

            }
            device.ConnectBus(this);
            Devices.Add(device);
        }

        public void DisconnectDevice(IDevice device)
        {
            device.DisconnectBus(this);
            Devices.Remove(device);
        }

        protected bool IsInAddressRange(uint requestAddress, uint deviceAddress, uint deviceSize)
            => requestAddress >= deviceAddress && requestAddress <= deviceAddress + deviceSize;

        public Response HandleRequest(Request request)
        {
            foreach (IDevice device in Devices)
            {
                if (IsInAddressRange(request.Address, device.BaseAddress, device.Size))
                {
                    request.Address -= device.BaseAddress;
                    return device.HandleRequest(request);
                }
            }
            return new Response(
                StatusCode.ERROR,
                request.Address,
                request.Data,
                $"ERROR REQUEST DOES NOT MATCH ANY DEVICE WITH ADDRESS 0x{request.Address:X8}"
            );
        }

        public void Step(ulong step_number)
        {
            foreach (IDevice device in Devices)
                device.Step(step_number);
        }
    }
}

