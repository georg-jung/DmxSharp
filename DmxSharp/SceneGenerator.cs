using System;
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
            throw new NotImplementedException();
        }

        public event EventHandler<SceneChangedEventArgs> SceneChanged;
    }
}