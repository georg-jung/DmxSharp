namespace DmxSharp.Interfaces
{
    public interface IController
    {
        IUniverse Universe { get; }
        ISceneTranslator SceneTranslator { get; }
        ISceneGenerator SceneGenerator { get; }
        byte[] CurrentData { get; }
    }
}