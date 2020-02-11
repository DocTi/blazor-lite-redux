namespace LiteRedux.Example.Redux
{
    public class IncrementActionReducer : Reducer<CounterState, IncrementAction>
    {
        protected override CounterState Reduce(CounterState state, IncrementAction action)
        {
            return new CounterState(state.Value + 1);
        }
    }
}
