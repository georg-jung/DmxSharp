using DmxSharp.Devices;

namespace DmxSharp.DeviceStates
{
    public class DrgbLightState : ColorDeviceState<DrgbLight>
    {
        public DrgbLightState(DrgbLight device) : base(device)
        {
        }

        public override byte[] Data => Color.GetDrgb();
    }
}