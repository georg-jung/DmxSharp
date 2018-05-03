using System.Collections.Generic;
using DmxSharp.Interfaces;

namespace DmxSharp
{
    public class Scene : IScene
    {
        public IReadOnlyCollection<IDeviceState<IDevice>> DeviceStates { get; }
        public IReadOnlyCollection<IDeviceGroupState<IDeviceGroup>> DeviceGroupStates { get; }
    }
}