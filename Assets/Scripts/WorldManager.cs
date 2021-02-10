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

        private void Start()
        {
            objectsFactory = new ObjectsFactory();
            objectsPhysics = new ObjectsPhysics();
            objectsHolder = new ObjectsHolder();

            objectsFactory.Setup(spawnParams, physicsParams, displayParams, objectsPhysics, objectsHolder);
            objectsPhysics.Setup(objectsHolder, physicsParams);

            RestartLevel();
        }

        public void RestartLevel()
        {
            objectsHolder.DestoyAll();
            objectsFactory.ConstructModels();
            objectsPhysics.UpdatePhysics(0f);
            objectsFactory.ConstructDisplays();
        }

        private void Update() =>
            objectsPhysics.UpdatePhysics(Time.deltaTime);
    }
}