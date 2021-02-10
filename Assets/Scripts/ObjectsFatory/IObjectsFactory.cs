namespace TEDinc.OrbsWorld
{
    public interface IObjectsFactory
    {
        void Setup(ISpawnParams spawnParams, IPhysicsParams physicsParams, IDisplayParams displayParams,
            IObjectsPhysics objectsPhysics, IObjectsHolder objectsHolder, IPlayerManager playerManager);
        void ConstructModels();
        void ConstructDisplays();
    }
}