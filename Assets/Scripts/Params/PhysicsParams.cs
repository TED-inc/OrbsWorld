using System;
using UnityEngine;

namespace TEDinc.OrbsWorld
{
    [Serializable]
    public sealed class PhysicsParams : IPhysicsParams
    {
        public float DestroyRadius => destroyRadius;
        public float FrictionDeceleration => frictionDeceleration;
        public Rect Walls => wallsRectTransform.rect;
        public float PlayerAcceleration => playerAcceleration;

        [SerializeField]
        private float destroyRadius = 5f;
        [SerializeField]
        private float frictionDeceleration = 50f;
        [SerializeField]
        private float playerAcceleration = 1000f;
        [SerializeField]
        public RectTransform wallsRectTransform;
    }
}