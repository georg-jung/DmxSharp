using System;
using System.Collections.Generic;
using System.Text;

namespace DmxSharp.Interfaces
{
    public interface ISignalGenerator
    {
        event EventHandler<SignalEventArgs> Signal;
    }
}
