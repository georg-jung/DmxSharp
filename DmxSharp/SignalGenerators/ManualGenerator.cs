using System;
using DmxSharp.Interfaces;

namespace DmxSharp.SignalGenerators
{
    public class ManualGenerator : ISignalGenerator
    {
        public class ManualSignal : ISignal
        {
        }

        public event EventHandler<SignalEventArgs> Signal;

        public void Trigger()
        {
            Signal?.Invoke(this, new SignalEventArgs(new ManualSignal()));
        }
    }
}