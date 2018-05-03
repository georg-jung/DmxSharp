using DmxSharp.Interfaces;

namespace DmxSharp
{
    public class Controller : ControllerBase
    {
        private readonly ISignalGenerator _signalGenerator;

        public Controller(IUniverse universe, ISceneTranslator sceneTranslator, ISceneGeneratorFactory sceneGeneratorFactory, ISignalGenerator signalGenerator) : base(universe, sceneTranslator, sceneGeneratorFactory)
        {
            _signalGenerator = signalGenerator;
            _signalGenerator.Signal += SignalGenerator_Signal;
        }

        private void SignalGenerator_Signal(object sender, SignalEventArgs e)
        {
            OnSignal(e.Signal);
        }
    }
}