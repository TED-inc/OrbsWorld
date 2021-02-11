using System;
using UnityEngine;

namespace TEDinc.OrbsWorld
{
    // TODO : separate IObjectData
    public interface IObjectModel
    {
        Vector2 Position { get; }
        bool IsDestoyed { get; }

        float GetAvgRadius();

        float GetMass();
        void SetMass(float mass);

        void Setup(float mass, Vector2 position, Vector2 velocity, IPhysicsParams physicsParams);

        void Accelerate(Vector2 velocity);
        void InteractWith(IObjectModel otherObject);
        void UpdatePhysics(float deltaTime);
        void Destroy();
    }
}