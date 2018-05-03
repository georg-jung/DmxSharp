namespace DmxSharp.Interfaces
{
    public interface IController
    {
        IUniverse Universe { get; }
        ISceneTranslator SceneTranslator { get; }
        byte[] CurrentData { get; }
    }
}