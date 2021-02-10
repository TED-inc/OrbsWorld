﻿using UnityEngine;

namespace TEDinc.OrbsWorld
{
    public sealed class ObjectsFactory : IObjectsFactory
    {
        private ISpawnParams spawnParams;
        private IPhysicsParams physicsParams;
        private IDisplayParams displayParams;

        private IObjectsPhysics objectsPhysics;
        private IObjectsHolder objectsHolder;

        public void Setup(ISpawnParams spawnParams, IPhysicsParams physicsParams, IDisplayParams displayParams, IObjectsPhysics objectsPhysics, IObjectsHolder objectsHolder)
        {
            this.spawnParams = spawnParams;
            this.physicsParams = physicsParams;
            this.displayParams = displayParams;

            this.objectsPhysics = objectsPhysics;
            this.objectsHolder = objectsHolder;
        }

        public void ConstructModels()
        {
            IObjectModel[] objectModels = new OrbModel[spawnParams.TargetOpponentCount];

            for (int i = 0; i < objectModels.Length; i++)
            {
                objectModels[i] = new OrbModel();
                objectModels[i].Setup(
                    Random.Range(spawnParams.MinOpponentMass, spawnParams.MaxOpponentMass),
                    GetRandomPos(),
                    Random.insideUnitCircle * spawnParams.MaxStartSpeed,
                    physicsParams);
            }

            Vector2 GetRandomPos() =>
                new Vector2(
                    Random.Range(physicsParams.Walls.xMin, physicsParams.Walls.xMax),
                    Random.Range(physicsParams.Walls.yMin, physicsParams.Walls.yMax));

            objectsHolder.objects = objectModels;
        }

        public void ConstructDisplays()
        {
            foreach (Transform child in spawnParams.OrbsParent)
                GameObject.Destroy(child.gameObject);

            for (int i = 0; i < objectsHolder.objects.Length; i++)
                if (objectsHolder.objects[i] != null)
                {
                    ObjectDisplay orbDisplay = GameObject.Instantiate(spawnParams.ObjectDisplayPrefab, spawnParams.OrbsParent);
                    orbDisplay.Setup(objectsHolder.objects[i], objectsPhysics);
                }
        }
    }
}