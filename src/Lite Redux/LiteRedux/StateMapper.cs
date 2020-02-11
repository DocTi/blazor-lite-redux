using System;
using System.Collections.Generic;
using System.Linq;

namespace LiteRedux
{
    public class StateMapper<TState> : IStateMapper<TState> where TState : class
    {
        private readonly IEnumerable<IReducer<TState>> reducers;

        public StateMapper(IEnumerable<IReducer<TState>> reducers)
        {
            this.reducers = reducers;

            State = InitState();
        }

        public TState State { get; private set; }

        public event Action StateHasChanged;

        public void ReduceAction(object action)
        {
            IEnumerable<IReducer<TState>> acceptedReducers = reducers.Where(x => x.ShouldAction(action));
            TState newState = State;
            foreach (var reducer in acceptedReducers)
            {
                newState = reducer.Reduce(newState, action);
            }

            if (State != newState)
            {
                State = newState;
                StateHasChanged?.Invoke();
            }
        }

        private TState InitState()
        {
            return Activator.CreateInstance<TState>();
        }
    }
}
