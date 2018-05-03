using System;
using System.Collections.Generic;
using System.Text;
using DmxSharp.Interfaces;

namespace DmxSharp.Filters.Scene
{
    public abstract class SceneFilterBase<TScene> : ISceneFilter<TScene> where TScene : IScene
    {
        public bool Active { get; set; }
        public abstract TScene Filter(TScene scene);
    }
}
