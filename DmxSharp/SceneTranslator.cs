using System;
using System.Collections.Generic;
using System.Linq;
using DmxSharp.Extensions;
using DmxSharp.Interfaces;

namespace DmxSharp
{
    public class SceneTranslator : ISceneTranslator
    {
        IReadOnlyList<IDeviceFilter> ISceneTranslator.DeviceFilters => DeviceFilters;
        IReadOnlyList<ISceneFilter<IScene>> ISceneTranslator.SceneFilters => SceneFilters;

        public List<IDeviceFilter<IDevice>> DeviceFilters { get; } = new List<IDeviceFilter<IDevice>>();
        public List<ISceneFilter<IScene>> SceneFilters { get; } = new List<ISceneFilter<IScene>>();
        public byte[] GetData(IScene scene, IUniverse universe)
        {
            var data = new byte[512];
            var currentScene = SceneFilters.Where(filter => filter.Active).Aggregate(scene, (current, filter) => filter.Filter(current));
            foreach (var state in currentScene.DeviceStates)
            {
                var device = state.Device;
                var deviceType = state.GetDeviceType();
                var currentState = state;
                foreach (var filter in DeviceFilters.Where(f => f.Active))
                {
                    var filterType = filter.GetDeviceType();
                    if (filterType.IsAssignableFrom(deviceType))
                        currentState = filter.Filter(currentState);
                }
                if (currentState.Data.Length != device.ChannelsCount) throw new InvalidOperationException($"device {device.Identifier} should have {device.ChannelsCount} channels but it's state's payload is {currentState.Data.Length}.");
                currentState.Data.CopyTo(data, universe.Devices[device] - 1);
            }
            return data;
        }
    }
}