namespace DmxSharp.Interfaces
{
    public interface ISceneGeneratorFactory
    {
        ISceneGenerator CreateGenerator(IUniverse universe);
    }
}