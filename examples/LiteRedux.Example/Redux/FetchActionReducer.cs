namespace LiteRedux.Example.Redux
{
    public class FetchActionReducer : Reducer<FetchDataState, FetchAction>
    {
        protected override FetchDataState Reduce(FetchDataState state, FetchAction action)
        {
            return new FetchDataState(true, null);
        }
    }
}
