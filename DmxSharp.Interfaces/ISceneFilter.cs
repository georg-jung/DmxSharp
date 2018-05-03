namespace DmxSharp.Interfaces
{
    public interface ISceneFilter<TScene> where TScene : IScene
    {
        bool Active { get; set; }
        TScene Filter(TScene scene);
    }
}