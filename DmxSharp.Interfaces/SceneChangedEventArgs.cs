using System;

namespace DmxSharp.Interfaces
{
    public class SceneChangedEventArgs : EventArgs
    {
        public SceneChangedEventArgs(ISignal trigger, IScene scene)
        {
            Trigger = trigger;
            Scene = scene;
        }

        public ISignal Trigger { get; }

        public IScene Scene { get; }
    }
}