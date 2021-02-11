namespace TEDinc.OrbsWorld
{
    public interface IPlayerManager
    {
        event Notify OnPlayerWin;
        event Notify OnPlayerDefeat;

        IPlayerModel player { get; }
        void Setup(ISpawnParams spawnParams, IPhysicsParams physicsParams, IObjectsHolder objectsHolder);
        void CreateBeferePlayerCleaner();
        void CreatePlayerInstaedOfCleaner();
        void Update(float deltaTime);
    }
}