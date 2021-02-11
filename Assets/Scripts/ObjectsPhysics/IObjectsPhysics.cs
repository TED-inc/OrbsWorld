namespace TEDinc.OrbsWorld
{
    public delegate void Notify();

    public interface IObjectsPhysics
    {
        event Notify OnPhysicUpdateDone;
        void Setup(IObjectsHolder objectsHolder, IPhysicsParams physicsParams);
        // TODO : make async
        void UpdatePhysics(float deltaTime);
    }
}