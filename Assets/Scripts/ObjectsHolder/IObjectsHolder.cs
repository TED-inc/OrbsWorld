namespace TEDinc.OrbsWorld
{
    public interface IObjectsHolder
    {
        IObjectModel[] objects { get; set; }
        void DestoyAll();
        void TryClearDestoyedObjects();
    }
}