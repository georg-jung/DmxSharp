using DmxSharp.Devices;
using DmxSharp.Interfaces;

namespace DmxSharp.DeviceStates
{
    public class RgbLightState : ColorDeviceState<RgbLight>
    {
        public RgbLightState(RgbLight device) : base(device)
        {
        }

        public override byte[] Data => Color.GetRgb();
    }
}