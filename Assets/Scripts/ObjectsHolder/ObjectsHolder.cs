using System.Linq;

namespace TEDinc.OrbsWorld
{
    public sealed class ObjectsHolder : IObjectsHolder
    {
        const float minDiffFactor = 1.1f;

        public IObjectModel[] objects { get; set; }

        public void DestoyAll()
        {
            if (objects != null)
                foreach (IObjectModel item in objects)
                    if (item != null)
                        item.Destroy();
        }

        public void TryClearDestoyedObjects()
        {
            int aliveObjectsCount = 0;

            for (int i = 0; i < objects.Length; i++)
                if (objects[i] == null || objects[i].IsDestoyed)
                    aliveObjectsCount++;

            if (aliveObjectsCount / (float)objects.Length > minDiffFactor)
                objects = objects.Where(o => o != null).ToArray();
        }
    }
}