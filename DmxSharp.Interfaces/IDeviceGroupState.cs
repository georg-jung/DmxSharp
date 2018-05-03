using System;
using System.Collections.Generic;
using System.Text;

namespace DmxSharp.Interfaces
{
    public interface IDeviceGroupState<out TDeviceGroup> where TDeviceGroup : IDeviceGroup
    {
        TDeviceGroup DeviceGroup { get; }
        IReadOnlyCollection<IDeviceState<IDevice>> DeviceStates { get; }
        bool IsActive { get; }
    }
}
