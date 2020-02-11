using System;

namespace LiteRedux
{
    public interface IState<TState>
    {
        TState Value { get; }

        void Subscribe(Action action);
        void Unsubscribe(Action action);
    }
}
