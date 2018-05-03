using System;
using System.Collections.Generic;
using System.Text;

namespace DmxSharp.Interfaces
{
    public interface IDeviceState<out TDevice> where TDevice : IDevice
    {
        TDevice Device { get; }
        bool IsActive { get; }
        byte[] Data { get; }
    }
}
