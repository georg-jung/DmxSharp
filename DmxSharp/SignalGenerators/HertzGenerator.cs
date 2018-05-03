using System;
using System.Threading;
using DmxSharp.Interfaces;

namespace DmxSharp.SignalGenerators
{
    public class HertzGenerator : ISignalGenerator
    {
        public class HertzSignal : ISignal
        {
        }

        private readonly Timer _timer;

        public event EventHandler<SignalEventArgs> Signal;

        public HertzGenerator(int frequencyMillisec = 1000)
        {
            _timer = new Timer(Timer_Tick, null, 0, frequencyMillisec);
        }

        private void Timer_Tick(object state)
        {
            Signal?.Invoke(this, new SignalEventArgs(new HertzSignal()));
        }
    }
}