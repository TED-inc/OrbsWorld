using UnityEngine;

namespace TEDinc.OrbsWorld
{
    public interface IDisplayParams
    {
        Color PlayerColor { get; }
        Gradient OponentsColorRange { get; }
        float GradientMassFactor { get; }
    }
}