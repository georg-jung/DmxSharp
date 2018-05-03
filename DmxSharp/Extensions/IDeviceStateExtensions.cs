using System;
using DmxSharp.Interfaces;

namespace DmxSharp.Extensions
{
    public static class IDeviceStateExtensions
    {
        public static Type GetDeviceType<T>(this IDeviceState<T> state) where T : IDevice
        {
            return typeof(T);
        }
    }
}