using System;
using UnityEngine;

namespace TEDinc.OrbsWorld
{
    [Serializable]
    public sealed class DisplayParams : IDisplayParams
    {
        public Color PlayerColor => playerColor;
        public Gradient OponentsColorRange => oponentsColorRange;
        public float GradientMassFactor => gradientMassFactor;

        [SerializeField]
        private Color playerColor;
        [SerializeField]
        private Gradient oponentsColorRange;
        [SerializeField]
        private float gradientMassFactor = 1.05f;
    }
}