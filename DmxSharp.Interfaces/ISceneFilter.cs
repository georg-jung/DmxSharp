namespace DmxSharp.Interfaces
{
    public interface ISceneFilter<TScene> where TScene : IScene
    {
        TScene Filter(TScene scene);
    }
}