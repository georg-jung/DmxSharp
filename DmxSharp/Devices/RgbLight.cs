using System;
using DmxSharp.DeviceStates;
using DmxSharp.Interfaces;

namespace DmxSharp.Devices
{
    public class RgbLight : ColorDevice
    {
        public RgbLight(Guid identifier) : base(identifier)
        {
        }

        public override int ChannelsCount => 3;
        public override IDeviceState<IDevice> CreateState()
        {
            return new RgbLightState(this);
        }
    }
}