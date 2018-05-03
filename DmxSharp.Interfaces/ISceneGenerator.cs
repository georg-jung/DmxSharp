using System;

namespace DmxSharp.Interfaces
{
    public interface ISceneGenerator
    {
        IScene CurrentScene { get; }
        IUniverse Universe { get; }
        void Signal(ISignal signal);
        event EventHandler<SceneChangedEventArgs> SceneChanged;
    }
}