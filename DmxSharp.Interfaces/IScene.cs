using System;
using System.Collections.Generic;
using System.Text;

namespace DmxSharp.Interfaces
{
    public interface IScene
    {
        IReadOnlyCollection<IDeviceState<IDevice>> DeviceStates { get; }
        IReadOnlyCollection<IDeviceGroupState<IDeviceGroup>> DeviceGroupStates { get; }
    }
}
