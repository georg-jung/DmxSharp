using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DmxSharp.Extensions;
using DmxSharp.Interfaces;

namespace DmxSharp.Filters.Scene
{
    public class SceneBlackout : SceneFilterBase<IScene>
    {
        protected class BlackoutScene : IScene
        {
            public IScene BaseScene { get; }

            public Lazy<List<IDeviceState<IDevice>>> _blackoutStates;

            public BlackoutScene(IScene baseScene)
            {
                BaseScene = baseScene;
                _blackoutStates = new Lazy<List<IDeviceState<IDevice>>>(BaseScene.DeviceStates.Blackout().ToList);
            }

            public IReadOnlyCollection<IDeviceState<IDevice>> DeviceStates => _blackoutStates.Value;
        }

        public override IScene Filter(IScene scene)
        {
            return new BlackoutScene(scene);
        }
    }
}
