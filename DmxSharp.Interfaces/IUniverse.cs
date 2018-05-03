using System;
using System.Collections.Generic;
using System.Text;

namespace DmxSharp.Interfaces
{
    public interface IUniverse
    {
        IReadOnlyDictionary<IDevice, int> Devices { get; }
        IReadOnlyCollection<IDeviceGroup> DeviceGroups { get; }
    }
}
