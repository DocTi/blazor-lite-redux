namespace LiteRedux
{
    public interface IStore
    {
        void Dispatch(object action);
    }
}
