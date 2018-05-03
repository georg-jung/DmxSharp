using System;
using DmxSharp.Devices;
using DmxSharp.DeviceStates;
using DmxSharp.Interfaces;
using DmxSharp.Models;

namespace DmxSharp.Sample
{
    public class ColorSceneGenerator : ISceneGenerator
    {
        public Color Color { get; set; }

        public ColorSceneGenerator(IUniverse universe)
        {
            Universe = universe;
        }

        public IUniverse Universe { get; }
        public void Signal(ISignal signal)
        {
            var scene = new Scene();

            foreach (var device in Universe.Devices.Keys)
            {
                if (device is ColorDevice colorDev)
                {
                    var colorState = device.CreateState();

                    var rgbState = new RgbLightState(rgbLight) {Color = Color};
                    scene.DeviceStates.Add(rgbState);
                }
            }

            var e = new SceneChangedEventArgs(signal, scene);
            SceneChanged?.Invoke(this, e);
        }

        public event EventHandler<SceneChangedEventArgs> SceneChanged;
    }
}