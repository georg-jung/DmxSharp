using System;
using System.Threading;
using DmxSharp.Interfaces;

namespace DmxSharp.SignalGenerators
{
    public class HertzGenerator : ISignalGenerator
    {
        public class HertzSignal : ISignal
        {
            public HertzSignal(int frequency)
            {
                Frequency = frequency;
            }

            public int Frequency { get; }
        }

        private readonly Timer _timer;
        private readonly int _frequency;

        public event EventHandler<SignalEventArgs> Signal;

        public HertzGenerator(int frequencyMillisec = 1000)
        {
            _frequency = frequencyMillisec;
            _timer = new Timer(Timer_Tick, null, 0, _frequency);
        }

        private void Timer_Tick(object state)
        {
            Signal?.Invoke(this, new SignalEventArgs(new HertzSignal(_frequency)));
        }
    }
}