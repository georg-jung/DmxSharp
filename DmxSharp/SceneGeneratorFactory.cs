using DmxSharp.Interfaces;

namespace DmxSharp
{
    public class SceneGeneratorFactory : ISceneGeneratorFactory
    {
        public ISceneGenerator CreateGenerator(IUniverse universe)
        {
            return new SceneGenerator(universe);
        }
    }
}