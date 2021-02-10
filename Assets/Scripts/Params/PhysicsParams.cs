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

        [SerializeField]
        private float destroyRadius = 5f;
        [SerializeField]
        private float frictionDeceleration = 0.1f;
        [SerializeField]
        public RectTransform wallsRectTransform;
    }
}