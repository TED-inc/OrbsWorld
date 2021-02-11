namespace TEDinc.OrbsWorld
{
    public interface IPlayerModel
    {
        // TODO : change to IObjectData after implement
        IObjectModel model { get; } 
        void Setup(IObjectModel model);
    }
}