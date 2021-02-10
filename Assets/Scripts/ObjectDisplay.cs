using UnityEngine;
using UnityEngine.UI;

namespace TEDinc.OrbsWorld
{
    public sealed class ObjectDisplay : MonoBehaviour
    {
        [SerializeField]
        private Image image;
        [SerializeField]
        private float scaleFactor = 100f;
        [SerializeField, Range(0.001f, 1f)]
        private float scaleLerpfactor = 0.05f;

        private IObjectModel model;
        private IObjectsPhysics objectsPhysics;

        public void Setup(IObjectModel model, IObjectsPhysics objectsPhysics)
        {
            this.model = model;
            this.objectsPhysics = objectsPhysics;
            objectsPhysics.OnPhysicUpdateDone += AfterPhysicsDone;
            transform.localScale = Vector3.one / scaleFactor;
        }

        private void AfterPhysicsDone()
        {
            if (model.IsDestoyed)
            {
                model = null;
                objectsPhysics.OnPhysicUpdateDone -= AfterPhysicsDone;
                Destroy(gameObject);
                return;
            }

            transform.localPosition = model.Position;
            transform.localScale = Vector3.Lerp(
                transform.localScale, 
                Vector3.one * model.GetAvgRadius() / scaleFactor,
                scaleLerpfactor);
        }
    }
}