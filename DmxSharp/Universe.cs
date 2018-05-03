using System;
using System.Collections.Generic;
using DmxSharp.Interfaces;

namespace DmxSharp
{
    public class Universe : IUniverse
    {
        private readonly IDevice[] _channelAllocation;
        private readonly Dictionary<IDevice, int> _devices = new Dictionary<IDevice, int>();

        public Universe()
        {
            _channelAllocation = new IDevice[511];
        }

        public IDevice GetDeviceAtChannel(int channel)
        {
            return _channelAllocation[channel];
        }

        public bool CanAddDevice(IDevice device, int firstChannelOffset)
        {
            if (_devices.ContainsKey(device)) return false;
            for (var i = firstChannelOffset; i <= firstChannelOffset + device.ChannelsCount - 1; ++i)
            {
                if (_channelAllocation[i] != null) return false;
            }
            return true;
        }

        public bool TryAddDevice(IDevice device, int firstChannelOffset)
        {
            if (!CanAddDevice(device, firstChannelOffset)) return false;
            for (var i = firstChannelOffset; i <= firstChannelOffset + device.ChannelsCount - 1; ++i)
            {
                _channelAllocation[i] = device;
            }
            _devices.Add(device, firstChannelOffset);
            return true;
        }

        public bool RemoveDevice(IDevice device)
        {
            if (!_devices.ContainsKey(device)) return false;
            _devices.Remove(device);
            var offset = _devices[device];
            var length = device.ChannelsCount;
            for (var i = offset; i <= offset + length - 1; ++i)
            {
                if (_channelAllocation[i] != device) throw new InvalidOperationException("This universe has a corrupted state.");
                _channelAllocation[i] = null;
            }
            return true;
        }

        public IReadOnlyDictionary<IDevice, int> Devices => _devices;
        public List<IDeviceGroup> DeviceGroups { get; } = new List<IDeviceGroup>();
        IReadOnlyCollection<IDeviceGroup> IUniverse.DeviceGroups => DeviceGroups;
    }
}