using System.Collections.Generic;
using DmxSharp.Interfaces;

namespace DmxSharp
{
    public class Scene : IScene
    {
        IReadOnlyCollection<IDeviceState<IDevice>> IScene.DeviceStates => DeviceStates;
        IReadOnlyCollection<IDeviceGroupState<IDeviceGroup>> IScene.DeviceGroupStates => DeviceGroupStates;

        public List<IDeviceState<IDevice>> DeviceStates { get; } = new List<IDeviceState<IDevice>>();
        public List<IDeviceGroupState<IDeviceGroup>> DeviceGroupStates { get; } = new List<IDeviceGroupState<IDeviceGroup>>();
    }
}