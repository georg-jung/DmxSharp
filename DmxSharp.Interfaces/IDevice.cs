using System;

namespace DmxSharp.Interfaces
{
    public interface IDevice
    {
        Guid Identifier { get; }
        string FriendlyName { get; }
        int ChannelsCount { get; }
    }
}
