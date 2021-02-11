using UnityEngine;

namespace TEDinc.OrbsWorld
{
    public sealed class PlayerManager : IPlayerManager
    {
        public event Notify OnPlayerWin;
        public event Notify OnPlayerDefeat;
        public IPlayerModel player { get; private set; }

        private ISpawnParams spawnParams;
        private IPhysicsParams physicsParams;
        private IObjectsHolder objectsHolder;

        private const int createIndex = 0;
        

        public void CreateBeferePlayerCleaner() =>
            CreateMock(OrbModel.GetMass(spawnParams.ClearRadiusForPlayer));

        public void CreatePlayerInstaedOfCleaner()
        {
            CreateMock(spawnParams.PlayerMass);
            player = new PlayerModel();
            player.Setup(objectsHolder.objects[createIndex]);
        }

        private void CreateMock(float mass)
        {
            objectsHolder.objects[createIndex].Destroy();
            objectsHolder.objects[createIndex] = new OrbModel();
            objectsHolder.objects[createIndex].Setup(mass, Vector2.zero, Vector2.zero, physicsParams);
        }

        public void Setup(ISpawnParams spawnParams, IPhysicsParams physicsParams, IObjectsHolder objectsHolder)
        {
            this.spawnParams = spawnParams;
            this.physicsParams = physicsParams;
            this.objectsHolder = objectsHolder;
        }

        public void Update(float deltaTime)
        {
            if (ChecPlayerDefeat() || CheckPlayerWin())
                return;

            Accelerate();


            bool ChecPlayerDefeat()
            {
                if (player.model.IsDestoyed)
                    OnPlayerDefeat?.Invoke();

                return player.model.IsDestoyed;
            }

            bool CheckPlayerWin()
            {
                float maxMass = 0f;
                float plyerMass = player.model.GetMass();

                foreach (IObjectModel model in objectsHolder.objects)
                    if (model != null)
                    {
                        float mass = model.GetMass();
                        if (mass > maxMass)
                        {
                            maxMass = mass;
                            if (maxMass > plyerMass)
                                return false;
                        }
                    }

                    OnPlayerWin?.Invoke();
                return true;
            }

            void Accelerate()
            {
                if (!Input.GetKey(KeyCode.Mouse0))
                    return;
                // TODO : remove dependency from Camera.main
                Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 localPos = spawnParams.ObjectsParent.InverseTransformPoint(worldPos);
                Vector2 moveDirection = player.model.Position - localPos;
                moveDirection.Normalize();
                player.model.Accelerate(moveDirection * deltaTime * physicsParams.PlayerAcceleration);
            }
        }
    }
}