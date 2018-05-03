using System;
using System.Collections.Generic;
using System.Text;
using DmxSharp.Devices;

namespace DmxSharp.DeviceStates
{
    public class RgbwLightState : ColorDeviceState<RgbwLight>
    {
        public RgbwLightState(RgbwLight device) : base(device)
        {
        }

        public override byte[] Data => Color.GetRgbw();
    }
}
