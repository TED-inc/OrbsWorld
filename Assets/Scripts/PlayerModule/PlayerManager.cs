using UnityEngine;

namespace TEDinc.OrbsWorld
{
    public sealed class PlayerManager : IPlayerManager
    {
        public IPlayerModel player => throw new System.NotImplementedException();

        private ISpawnParams spawnParams;
        private IPhysicsParams physicsParams;
        private IObjectsHolder objectsHolder;

        public void CreateBeferePlayerCleaner() =>
            CreateMock(OrbModel.GetMass(spawnParams.ClearRadiusForPlayer));

        public void CreatePlayerInstaedofCleaner()
        {
            CreateMock(spawnParams.PlayerMass);
        }

        private void CreateMock(float mass)
        {
            objectsHolder.objects[0].Destroy();
            objectsHolder.objects[0] = new OrbModel();
            objectsHolder.objects[0].Setup(mass, Vector2.zero, Vector2.zero, physicsParams);
        }

        public void Setup(ISpawnParams spawnParams, IPhysicsParams physicsParams, IObjectsHolder objectsHolder)
        {
            this.spawnParams = spawnParams;
            this.physicsParams = physicsParams;
            this.objectsHolder = objectsHolder;
        }
    }
}