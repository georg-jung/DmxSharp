using System;
using System.Collections.Generic;
using System.Text;
using DmxSharp.DeviceStates;
using DmxSharp.Interfaces;

namespace DmxSharp.Devices
{
    public abstract class ColorDevice : DeviceBase
    {
        protected ColorDevice(Guid identifier) : base(identifier)
        {
        }
    }
}
