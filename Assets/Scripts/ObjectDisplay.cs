using UnityEngine;
using UnityEngine.UI;

namespace TEDinc.OrbsWorld
{
    // TODO : inherit from interface and remove all external dependencies to class
    public sealed class ObjectDisplay : MonoBehaviour
    {
        [SerializeField]
        private Image image;
        [SerializeField]
        private float scaleFactor = 100f;
        [SerializeField, Range(0.001f, 1f)]
        private float scaleLerpfactor = 0.05f;
        [SerializeField, Range(0.001f, 1f)]
        private float colorLerpfactor = 0.05f;

        // TODO : change to IObjectData after implementation
        private IObjectModel model;
        private IObjectsPhysics objectsPhysics;
        private IDisplayParams displayParams;
        private IPlayerManager playerManager;

        public void Setup(IObjectModel model, IObjectsPhysics objectsPhysics, IDisplayParams displayParams, IPlayerManager playerManager)
        {
            this.model = model;
            this.objectsPhysics = objectsPhysics;
            this.displayParams = displayParams;
            this.playerManager = playerManager;

            objectsPhysics.OnPhysicUpdateDone += AfterPhysicsDone;
            transform.localScale = Vector3.one / scaleFactor;
        }

        // TODO : change to support of async physics update
        private void AfterPhysicsDone()
        {
            if (model.IsDestoyed)
            {
                model = null;
                objectsPhysics.OnPhysicUpdateDone -= AfterPhysicsDone;
                Destroy(gameObject);
                return;
            }

            TweenPosition();
            TweenColor();



            void TweenPosition()
            {
                transform.localPosition = model.Position;
                transform.localScale = Vector3.Lerp(
                    transform.localScale,
                    Vector3.one * model.GetAvgRadius() / scaleFactor,
                    scaleLerpfactor);
            }

            void TweenColor()
            {
                if (model == playerManager.player.model)
                    image.color = displayParams.PlayerColor;
                else
                {
                    float massRatio = model.GetMass() / playerManager.player.model.GetMass();
                    float colorFactor = Mathf.InverseLerp(
                        1f / displayParams.GradientMassFactor,
                        displayParams.GradientMassFactor,
                        massRatio);
                    Color targetColor = Color.Lerp(
                        displayParams.OponentSmallerColor,
                        displayParams.OponentBiggherColor,
                        colorFactor);

                    image.color = Color.Lerp(image.color, targetColor, colorLerpfactor);
                }
            }
        }
    }
}