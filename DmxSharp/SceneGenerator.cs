using System;
using System.Drawing;
using DmxSharp.Devices;
using DmxSharp.DeviceStates;
using DmxSharp.Interfaces;

namespace DmxSharp
{
    public class SceneGenerator : ISceneGenerator
    {
        public SceneGenerator(IUniverse universe)
        {
            Universe = universe;
        }

        public IUniverse Universe { get; }
        public void Signal(ISignal signal)
        {
            var scene = new Scene();

            var e = new SceneChangedEventArgs(signal, scene);
            SceneChanged?.Invoke(this, e);
        }

        public event EventHandler<SceneChangedEventArgs> SceneChanged;
    }
}