namespace TEDinc.OrbsWorld
{
    public delegate void Notify();

    public interface IObjectsPhysics
    {
        event Notify OnPhysicUpdateDone;
        void Setup(IObjectsHolder objectsHolder, IPhysicsParams physicsParams);
        void UpdatePhysics(float deltaTime);
    }
}