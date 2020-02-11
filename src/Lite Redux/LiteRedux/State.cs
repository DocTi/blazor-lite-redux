using System;

namespace LiteRedux
{
    public class State<TState> : IState<TState>
    {
        private readonly IStateMapper<TState> mapper;

        public State(IStateMapper<TState> mapper)
        {
            this.mapper = mapper;
        }

        public TState Value
        {
            get
            {
                return mapper.State;
            }
        }

        public void Subscribe(Action action)
        {
            mapper.StateHasChanged += action;
        }

        public void Unsubscribe(Action action)
        {
            mapper.StateHasChanged -= action;
        }
    }
}
