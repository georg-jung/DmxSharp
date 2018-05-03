using DmxSharp.Interfaces;

namespace DmxSharp.Sample
{
    public class SceneGeneratorFactory : ISceneGeneratorFactory
    {
        public ISceneGenerator CreateGenerator(IUniverse universe)
        {
            return new RedSceneGenerator(universe);
        }
    }
}