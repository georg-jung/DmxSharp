using System;
using System.Collections;
using DmxSharp.Devices;
using DmxSharp.DeviceStates;
using DmxSharp.Interfaces;
using System.Collections.Generic;

namespace DmxSharp.Extensions
{
    public static class DeviceStateExtensions
    {
        public static IEnumerable<IDeviceState<IDevice>> Blackout(this IEnumerable<IDeviceState<IDevice>> states)
        {
            foreach (var state in states)
            {
                if (state.Device is IHasCustomBlackout customBlackout)
                    yield return customBlackout.GetBlackouState();
                else yield return new BlackoutDeviceState<IDevice>(state.Device);
            }
        }
    }
}