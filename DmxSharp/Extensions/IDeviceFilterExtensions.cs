using System;
using DmxSharp.Interfaces;

namespace DmxSharp.Extensions
{
    public static class IDeviceFilterExtensions
    {
        public static Type GetDeviceType<T>(this IDeviceFilter<T> filter) where T : IDevice
        {
            return typeof(T);
        }
    }
}