using System;
using System.Collections.Generic;
using System.Text;
using DmxSharp.Interfaces;

namespace DmxSharp.DeviceStates
{
    public class BlackoutDeviceState<TDevice> : IDeviceState<TDevice> where TDevice : IDevice
    {
        public BlackoutDeviceState(TDevice device)
        {
            Device = device;
        }

        public TDevice Device { get; }
        public bool IsActive => false;
        public byte[] Data => new byte[Device.ChannelsCount];
    }
}
