using System;
using UnityEngine;

namespace TEDinc.OrbsWorld
{
    [Serializable]
    public sealed class SpawnParams : ISpawnParams
    {
        public ObjectDisplay ObjectDisplayPrefab => objectDisplayPrefab;
        public Transform OrbsParent => orbsParent;

        public int TargetOpponentCount => targetOponentCount;
        public float MinOpponentMass => minOpponentMass;
        public float MaxOpponentMass => maxOpponentMass;
        public float MaxStartSpeed => maxStartSpeed;

        public float PlayerMass => playerMass;
        public float ClearRadiusForPlayer => clearRadiusForPlayer;

        [SerializeField]
        private ObjectDisplay objectDisplayPrefab;
        [SerializeField]
        private Transform orbsParent;

        [Header("Opponents")]
        [SerializeField]
        private int targetOponentCount = 1000;
        [SerializeField]
        private float minOpponentMass = 20f;
        [SerializeField]
        private float maxOpponentMass = 100f;
        [SerializeField]
        private float maxStartSpeed = 10f;

        [Header("Player")]
        [SerializeField]
        private float playerMass = 1000;
        [SerializeField]
        private float clearRadiusForPlayer = 20f;
    }
}