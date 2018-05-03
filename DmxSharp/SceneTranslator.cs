using System;
using System.Collections.Generic;
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
            foreach (var state in scene.DeviceStates)
            {
                var device = state.Device;
                var deviceType = state.GetDeviceType();
                var currentState = state;
                foreach (var filter in DeviceFilters)
                {
                    var filterType = filter.GetDeviceType();
                    if (filterType.IsAssignableFrom(deviceType))
                        currentState = filter.Filter(currentState);
                }
                currentState.Data.CopyTo(data, universe.Devices[device]);
            }
            return data;
        }
    }
}