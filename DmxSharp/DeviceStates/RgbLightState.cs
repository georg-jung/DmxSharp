using System.Drawing;
using DmxSharp.Devices;
using DmxSharp.Interfaces;

namespace DmxSharp.DeviceStates
{
    public class RgbLightState : IDeviceState<RgbLight>
    {
        public RgbLightState(RgbLight device)
        {
            Device = device;
        }

        public Color Color { get; set; }

        public RgbLight Device { get; }
        public bool IsActive => Color != Color.Black;
        public byte[] Data => new[] {Color.R, Color.G, Color.B};
    }
}