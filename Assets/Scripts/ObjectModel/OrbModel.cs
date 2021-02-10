using System;
using UnityEngine;

namespace TEDinc.OrbsWorld
{
    public sealed class OrbModel : IObjectModel
    {
        public Vector2 Position { get; private set; }
        public bool IsDestoyed { get; private set; }
        public bool IsPlayer { get; private set; }

        private float radius;
        private Vector2 velocity;
        private IPhysicsParams physicsParams;

        public static float GetMass(float radius) =>
            Mathf.PI * radius * radius;
        public float GetMass() =>
            GetMass(radius);
        public void SetMass(float mass) =>
            radius = Mathf.Sqrt(mass / Mathf.PI);
        public float GetAvgRadius() =>
            radius;


        public void InteractWith(IObjectModel otherObject)
        {
            if (otherObject is OrbModel)
                OrbInteractionStreategy(otherObject as OrbModel);
            else
                throw new NotImplementedException();



            void OrbInteractionStreategy(OrbModel other)
            {
                float colideDistance = radius + other.radius - (Position - other.Position).magnitude;

                if (colideDistance > 0)
                {
                    OrbModel smallerOrb = radius > other.radius ? other : this;
                    OrbModel biggerOrb = radius < other.radius ? other : this;

                    float radiusDelta = Mathf.Min(smallerOrb.radius, colideDistance);
                    float smallerOrbMassCashe = smallerOrb.GetMass();
                    smallerOrb.radius -= radiusDelta;
                    biggerOrb.SetMass(biggerOrb.GetMass() + smallerOrbMassCashe - smallerOrb.GetMass());
                }
            }
        }

        public void UpdatePhysics(float deltaTime)
        {
            Position += velocity * deltaTime;
            Vector2 newPosition = new Vector2(
                Mathf.Clamp(Position.x, physicsParams.Walls.xMin + radius, physicsParams.Walls.xMax - radius),
                Mathf.Clamp(Position.y, physicsParams.Walls.yMin + radius, physicsParams.Walls.yMax - radius));
            if (Mathf.Abs(newPosition.x - Position.x) > 0.01f)
                velocity = new Vector2(-velocity.x, velocity.y);
            if (Mathf.Abs(newPosition.y - Position.y) > 0.01f)
                velocity = new Vector2(velocity.x, -velocity.y);
            Position = newPosition;
        }

        public void Destroy() =>
            IsDestoyed = true;

        public void Setup(float mass, Vector2 position, Vector2 velocity, IPhysicsParams physicsParams, bool isPlayer = false)
        {
            SetMass(mass);
            Position = position;
            this.velocity = velocity;
            this.physicsParams = physicsParams;
            this.IsPlayer = isPlayer;
        }
    }
}