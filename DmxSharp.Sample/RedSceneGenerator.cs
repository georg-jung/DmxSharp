using System;
using System.Drawing;
using DmxSharp.Devices;
using DmxSharp.DeviceStates;
using DmxSharp.Interfaces;

namespace DmxSharp.Sample
{
    public class RedSceneGenerator : ISceneGenerator
    {
        public RedSceneGenerator(IUniverse universe)
        {
            Universe = universe;
        }

        public IUniverse Universe { get; }
        public void Signal(ISignal signal)
        {
            var scene = new Scene();

            foreach (var device in Universe.Devices.Keys)
            {
                if (device is RgbLight rgbLight)
                {
                    var rgbState = new RgbLightState(rgbLight) {Color = Color.Red};
                    scene.DeviceStates.Add(rgbState);
                }
            }

            var e = new SceneChangedEventArgs(signal, scene);
            SceneChanged?.Invoke(this, e);
        }

        public event EventHandler<SceneChangedEventArgs> SceneChanged;
    }
}