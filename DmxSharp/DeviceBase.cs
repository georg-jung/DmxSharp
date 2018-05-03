using System;
using DmxSharp.Interfaces;

namespace DmxSharp
{
    public abstract class DeviceBase : IDevice
    {
        protected DeviceBase(Guid identifier)
        {
            Identifier = identifier;
        }

        public Guid Identifier { get; }
        public string FriendlyName { get; set; }
        public abstract int ChannelsCount { get; }

        public override bool Equals(object obj)
        {
            return Identifier.Equals(obj);
        }

        public override int GetHashCode()
        {
            return Identifier.GetHashCode();
        }
    }
}