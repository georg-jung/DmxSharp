using System;
using System.Collections.Generic;
using System.Text;

namespace DmxSharp.Interfaces
{
    public interface ISceneTranslator
    {
        IReadOnlyList<IDeviceFilter<IDevice>> DeviceFilters { get; }
        IReadOnlyList<ISceneFilter<IScene>> SceneFilter { get; }
        byte[] GetData(IScene scene, IUniverse universe);
    }
}
