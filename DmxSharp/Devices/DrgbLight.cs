using System;
using System.Collections.Generic;
using System.Text;
using DmxSharp.DeviceStates;
using DmxSharp.Interfaces;

namespace DmxSharp.Devices
{
    public class DrgbLight : ColorDevice
    {
        public DrgbLight(Guid identifier) : base(identifier)
        {
        }

        public override int ChannelsCount => 4;
        public override IDeviceState<IDevice> CreateState()
        {
            return new DrgbLightState(this);
        }
    }
}
