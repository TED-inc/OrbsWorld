namespace TEDinc.OrbsWorld
{
    // TODO : separate IDisplayFactory
    public interface IObjectsFactory
    {
        void Setup(ISpawnParams spawnParams, IPhysicsParams physicsParams, IDisplayParams displayParams,
            IObjectsPhysics objectsPhysics, IObjectsHolder objectsHolder, IPlayerManager playerManager);
        void ConstructModels();
        void ConstructDisplays(); 
    }
}