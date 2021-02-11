using UnityEngine;

namespace TEDinc.OrbsWorld
{
    // TODO : separate UI manager 
    public sealed class WorldManager : MonoBehaviour
    {
        [SerializeField]
        private SpawnParams spawnParams;
        [SerializeField]
        private PhysicsParams physicsParams;
        [SerializeField]
        private DisplayParams displayParams;
        [SerializeField]
        private GameObject winPopup;
        [SerializeField]
        private GameObject defeatPopup;

        private IObjectsFactory objectsFactory;
        private IObjectsPhysics objectsPhysics;
        private IObjectsHolder objectsHolder;
        private IPlayerManager playerManager;

        private bool isPaused;

        private void Start()
        {
            objectsFactory = new ObjectsFactory();
            objectsPhysics = new ObjectsPhysics();
            objectsHolder = new ObjectsHolder();
            playerManager = new PlayerManager();

            objectsFactory.Setup(spawnParams, physicsParams, displayParams, objectsPhysics, objectsHolder, playerManager);
            objectsPhysics.Setup(objectsHolder, physicsParams);
            playerManager.Setup(spawnParams, physicsParams, objectsHolder);

            playerManager.OnPlayerWin += OnPlayerWin;
            playerManager.OnPlayerDefeat += OnPlayerDefeat;

            RestartLevel();
        }

        private void OnDestroy()
        {
            playerManager.OnPlayerWin -= OnPlayerWin;
            playerManager.OnPlayerDefeat -= OnPlayerDefeat;
        }

        public void RestartLevel()
        {
            winPopup.SetActive(false);
            defeatPopup.SetActive(false);

            objectsHolder.DestoyAll();
            objectsFactory.ConstructModels();
            playerManager.CreateBeferePlayerCleaner();
            objectsPhysics.UpdatePhysics(0f);
            playerManager.CreatePlayerInstaedOfCleaner();
            objectsFactory.ConstructDisplays();

            isPaused = false;
        }

        private void Update()
        {
            if (isPaused)
                return;

            objectsPhysics.UpdatePhysics(Time.deltaTime);
            playerManager.Update(Time.deltaTime);
        }

        private void OnPlayerWin()
        {
            isPaused = true;
            winPopup.SetActive(true);
        }
        private void OnPlayerDefeat()
        {
            isPaused = true;
            defeatPopup.SetActive(true);
        }
    }
}