namespace LiteRedux
{
    public abstract class Reducer<TState, TAction> : IReducer<TState>
    {
        protected abstract TState Reduce(TState state, TAction action);

        public TState Reduce(TState state, object action)
        {
            return Reduce(state, (TAction)action);
        }

        public bool ShouldAction(object action)
        {
            return action is TAction;
        }
    }
}
