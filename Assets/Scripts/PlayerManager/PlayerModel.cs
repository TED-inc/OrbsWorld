using UnityEngine;

namespace TEDinc.OrbsWorld
{
    public sealed class PlayerModel : IPlayerModel
    {
        public IObjectModel model { get; private set; }

        public void Setup(IObjectModel model) =>
            this.model = model;
    }
}