using UnityEngine;

namespace TEDinc.OrbsWorld
{
    public sealed class WorldManager : MonoBehaviour
    {
        [SerializeField]
        private SpawnParams spawnParams;
        [SerializeField]
        private PhysicsParams physicsParams;
        [SerializeField]
        private DisplayParams displayParams;

        private IObjectsFactory objectsFactory;
        private IObjectsPhysics objectsPhysics;
        private IObjectsHolder objectsHolder;
        private IPlayerManager playerManager;

        private void Start()
        {
            objectsFactory = new ObjectsFactory();
            objectsPhysics = new ObjectsPhysics();
            objectsHolder = new ObjectsHolder();
            playerManager = new PlayerManager();

            objectsFactory.Setup(spawnParams, physicsParams, displayParams, objectsPhysics, objectsHolder, playerManager);
            objectsPhysics.Setup(objectsHolder, physicsParams);
            playerManager.Setup(spawnParams, physicsParams, objectsHolder);

            RestartLevel();
        }

        public void RestartLevel()
        {
            objectsHolder.DestoyAll();
            objectsFactory.ConstructModels();
            playerManager.CreateBeferePlayerCleaner();
            objectsPhysics.UpdatePhysics(0f);
            playerManager.CreatePlayerInstaedofCleaner();
            objectsFactory.ConstructDisplays();
        }

        private void Update() =>
            objectsPhysics.UpdatePhysics(Time.deltaTime);
    }
}