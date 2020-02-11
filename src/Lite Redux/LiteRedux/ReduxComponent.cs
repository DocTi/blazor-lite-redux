using Microsoft.AspNetCore.Components;
using System;

namespace LiteRedux
{
    public class ReduxComponent<TState> : ComponentBase, IDisposable
    {
        [Inject]
        protected IState<TState> State { get; set; }

        [Inject]
        protected IStore Store { get; set; }

        protected override void OnInitialized()
        {
            State.Subscribe(StateHasChanged);
        }

        public virtual void Dispose()
        {
            State.Unsubscribe(StateHasChanged);
        }
    }
}
