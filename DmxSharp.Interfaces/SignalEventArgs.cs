using System;
using System.Collections.Generic;
using System.Text;

namespace DmxSharp.Interfaces
{
    public class SignalEventArgs : EventArgs
    {
        public SignalEventArgs(ISignal signal) => Signal = signal;

        public ISignal Signal { get; }
    }
}
