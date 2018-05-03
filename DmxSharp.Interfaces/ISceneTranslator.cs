using System;
using System.Collections.Generic;
using System.Text;

namespace DmxSharp.Interfaces
{
    public interface ISceneTranslator
    {
        IReadOnlyList<IDeviceFilter> DeviceFilters { get; }
        IReadOnlyList<ISceneFilter<IScene>> SceneFilters { get; }
        byte[] GetData(IScene scene, IUniverse universe);
    }
}
