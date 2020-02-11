using System;

namespace LiteRedux
{
    public interface IStateMapper
    {
        event Action StateHasChanged;

        void ReduceAction(object action);
    }

    public interface IStateMapper<TState> : IStateMapper
    {
        TState State { get; }
    }
}
