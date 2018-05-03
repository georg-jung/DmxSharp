using System.Collections.Generic;
using DmxSharp.Interfaces;

namespace DmxSharp
{
    public class Scene : IScene
    {
        IReadOnlyCollection<IDeviceState<IDevice>> IScene.DeviceStates => DeviceStates;
        
        public List<IDeviceState<IDevice>> DeviceStates { get; } = new List<IDeviceState<IDevice>>();
    }
}