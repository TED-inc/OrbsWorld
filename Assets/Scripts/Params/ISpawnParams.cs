using UnityEngine;

namespace TEDinc.OrbsWorld
{
    public interface ISpawnParams
    {
        ObjectDisplay ObjectDisplayPrefab { get; }
        Transform ObjectsParent { get; }


        int TargetOpponentCount { get; }
        float MinOpponentMass { get; }
        float MaxOpponentMass { get; }
        float MaxStartSpeed { get; }
        float PlayerMass { get; }
        float ClearRadiusForPlayer { get; }
    }
}