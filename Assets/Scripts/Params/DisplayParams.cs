using System;
using UnityEngine;

namespace TEDinc.OrbsWorld
{
    [Serializable]
    public sealed class DisplayParams : IDisplayParams
    {
        public Color PlayerColor => playerColor;
        public Color OponentSmallerColor => oponentSmallerColor;
        public Color OponentBiggherColor => oponentBiggherColor;
        public float GradientMassFactor => gradientMassFactor;


        [SerializeField]
        private Color playerColor = Color.gray;
        [SerializeField]
        private Color oponentSmallerColor = Color.blue;
        [SerializeField]
        private Color oponentBiggherColor = Color.red;
        [SerializeField]
        private float gradientMassFactor = 1.05f;
    }
}