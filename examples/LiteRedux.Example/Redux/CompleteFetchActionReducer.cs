namespace LiteRedux.Example.Redux
{
    public class CompleteFetchActionReducer : Reducer<FetchDataState, CompleteFetchAction>
    {
        protected override FetchDataState Reduce(FetchDataState state, CompleteFetchAction action)
        {
            return new FetchDataState(false, action.Data);
        }
    }
}
