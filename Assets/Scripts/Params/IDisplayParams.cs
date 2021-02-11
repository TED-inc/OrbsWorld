using UnityEngine;

namespace TEDinc.OrbsWorld
{
    public interface IDisplayParams
    {
        Color PlayerColor { get; }
        Color OponentSmallerColor { get; }
        Color OponentBiggherColor { get; }
        float GradientMassFactor { get; }
    }
}