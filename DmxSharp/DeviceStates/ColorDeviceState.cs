using DmxSharp.Devices;
using DmxSharp.Extensions;
using DmxSharp.Interfaces;
using DmxSharp.Models;

namespace DmxSharp.DeviceStates
{
    public abstract class ColorDeviceState<TDevice> : IDeviceState<TDevice> where TDevice : ColorDevice
    {
        protected ColorDeviceState(TDevice device)
        {
            Device = device;
        }

        public Color Color { get; set; }

        public TDevice Device { get; }
        public bool IsActive => Color.IsActive;
        public abstract byte[] Data { get; }
    }
}