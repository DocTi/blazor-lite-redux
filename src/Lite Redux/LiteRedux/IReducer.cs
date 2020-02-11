namespace LiteRedux
{
    public interface IReducer<TState>
    {
        TState Reduce(TState state, object action);
        bool ShouldAction(object action);
    }
}
