using System;

namespace DmxSharp.Interfaces
{
    public interface ISceneGenerator
    {
        IUniverse Universe { get; }
        void Signal(ISignal signal);
        event EventHandler<SceneChangedEventArgs> SceneChanged;
    }
}