using UnityEngine;

namespace TEDinc.OrbsWorld
{
    public interface IPhysicsParams
    {
        float DestroyRadius { get; }
        float FrictionDeceleration { get; }
        Rect Walls { get; }
    }
}