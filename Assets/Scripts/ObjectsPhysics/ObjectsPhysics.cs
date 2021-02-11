
namespace TEDinc.OrbsWorld
{
    public sealed class ObjectsPhysics : IObjectsPhysics
    {
        public event Notify OnPhysicUpdateDone;

        private IObjectsHolder objectsHolder;
        private IPhysicsParams physicsParams;

        private IObjectModel[] objects => objectsHolder.objects;
        

        public void Setup(IObjectsHolder objectsHolder, IPhysicsParams physicsParams)
        {
            this.objectsHolder = objectsHolder;
            this.physicsParams = physicsParams;
        }

        public void UpdatePhysics(float deltaTime)
        {
            InvokeObjectsUpdatePhysics();
            objectsHolder.TryClearDestoyedObjects();
            InteratAllObjects();

            OnPhysicUpdateDone?.Invoke();



            void InvokeObjectsUpdatePhysics()
            {
                for (int i = 0; i < objects.Length; i++)
                    if (objects[i] == null)
                        continue;
                    else if (objects[i].IsDestoyed)
                        objects[i] = null;
                    else if (objects[i].GetAvgRadius() < physicsParams.DestroyRadius)
                    {
                        objects[i].Destroy();
                        objects[i] = null;
                    }
                    else
                        objects[i].UpdatePhysics(deltaTime);
            }

            
            // TODO : optimize
            void InteratAllObjects()
            {
                for (int i = 0; i < objects.Length; i++)
                    if (objects[i] != null)
                        for (int j = i + 1; j < objects.Length; j++)
                            if (objects[j] != null)
                                objects[i].InteractWith(objects[j]);
            }
        }
    }
}