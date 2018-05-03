using System;
using System.Collections.Generic;
using System.Text;
using DmxSharp.Interfaces;

namespace DmxSharp.SignalGenerators
{
    public class CompositeGenerator : ISignalGenerator
    {
        private readonly HashSet<ISignalGenerator> _generators = new HashSet<ISignalGenerator>();

        public IReadOnlyCollection<ISignalGenerator> Generators => _generators;

        public void Add(ISignalGenerator generator)
        {
            if (_generators.Add(generator))
                generator.Signal += OnSignal;
        }

        public void Remove(ISignalGenerator generator)
        {
            if (_generators.Remove(generator))
                generator.Signal -= OnSignal;
        }

        private void OnSignal(object sender, SignalEventArgs e)
        {
            Signal?.Invoke(sender, e);
        }

        public event EventHandler<SignalEventArgs> Signal;
    }
}
