using System;
using System.Collections.Generic;
using System.Text;

namespace DmxSharp.Interfaces
{
    public interface IUniverse
    {
        IReadOnlyCollection<IDevice> Devices { get; }
        IReadOnlyCollection<IDeviceGroup> DeviceGroups { get; }
    }
}
