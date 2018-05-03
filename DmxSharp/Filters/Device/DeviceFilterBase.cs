using System;
using System.Collections.Generic;
using System.Text;
using DmxSharp.Interfaces;

namespace DmxSharp.Filters.Device
{
    public abstract class DeviceFilterBase<TDevice> : IDeviceFilter<TDevice> where TDevice : IDevice
    {
        public IDeviceState<TDevice> Filter(IDeviceState<TDevice> state)
        {
            throw new NotImplementedException();
        }

        public bool Active { get; set; }

        public IDeviceState<T> Filter<T>(IDeviceState<T> state) where T : IDevice
        {
            if (state == null) return null;
            IDeviceState<T> filtered = null;
            if (state is IDeviceState<TDevice> castS)
                filtered = Filter(castS) as IDeviceState<T>;
            if (filtered != null) return filtered;
            throw new InvalidOperationException($"This device filter can only filter DeviceStates for devices of type {typeof(TDevice).FullName} but got a {state.GetType().FullName} for device {typeof(T).FullName}.");
        }
    }
}
