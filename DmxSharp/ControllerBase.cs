using System;
using DmxSharp.Interfaces;

namespace DmxSharp
{
    public class ControllerBase : IController
    {
        // use the scene generator factory, because a specific SceneGenerator might be shared if given as argument
        public ControllerBase(IUniverse universe, ISceneTranslator sceneTranslator, ISceneGeneratorFactory sceneGeneratorFactory)
        {
            Universe = universe;
            SceneTranslator = sceneTranslator;
            SceneGenerator = sceneGeneratorFactory.CreateGenerator(Universe);
            SceneGenerator.SceneChanged += SceneChanged;
            SceneGenerator.Signal(StartupSignal.Value);
        }

        protected void OnSignal(ISignal signal)
        {
            SceneGenerator.Signal(signal);
        }

        private void SceneChanged(object sender, SceneChangedEventArgs e)
        {
            CurrentScene = e.Scene;
            LastSignal = e.Trigger;
            CurrentData = SceneTranslator.GetData(CurrentScene, Universe);
        }

        public ISignal LastSignal { get; private set; }

        public IScene CurrentScene { get; private set; }

        public IUniverse Universe { get; }
        public ISceneTranslator SceneTranslator { get; }
        public ISceneGenerator SceneGenerator { get; }
        public byte[] CurrentData { get; private set; }
    }
}
