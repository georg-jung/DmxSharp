using System;

namespace DmxSharp.Devices
{
    public class RgbLight : DeviceBase
    {
        public RgbLight(Guid identifier) : base(identifier)
        {
        }

        public override int ChannelsCount => 3;
    }
}