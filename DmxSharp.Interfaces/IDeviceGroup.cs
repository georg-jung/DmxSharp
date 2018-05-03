using System;
using System.Collections.Generic;
using System.Text;

namespace DmxSharp.Interfaces
{
    public interface IDeviceGroup
    {
        Guid Identifier { get; }
        string FriendlyName { get; }
        IReadOnlyCollection<IDevice> Devices { get; }
    }
}
