using UnityEngine;

namespace TEDinc.OrbsWorld
{
    public interface IPhysicsParams
    {
        float DestroyRadius { get; }
        float FrictionDeceleration { get; }
        float PlayerAcceleration { get; }
        Rect Walls { get; }
    }
}