namespace TEDinc.OrbsWorld
{
    public interface IPlayerManager
    {
        IPlayerModel player { get; }
        void Setup(ISpawnParams spawnParams, IPhysicsParams physicsParams, IObjectsHolder objectsHolder);
        void CreateBeferePlayerCleaner();
        void CreatePlayerInstaedofCleaner();
    }
}