using System;

namespace DmxSharp.Interfaces
{
    public class SceneChangedEventArgs : EventArgs
    {
        public SceneChangedEventArgs(ISignal trigger) => Trigger = trigger;

        public ISignal Trigger { get; }
    }
}