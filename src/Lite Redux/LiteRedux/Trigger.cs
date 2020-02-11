using System.Threading.Tasks;

namespace LiteRedux
{
    public abstract class Trigger<TAction> : ITrigger
    {
        protected abstract Task HandleAsync(TAction action, IStore store);

        public Task HandleAsync(object action, IStore store)
        {
            return HandleAsync((TAction)action, store);
        }

        public bool ShouldAction(object action)
        {
            return action is TAction;
        }
    }
}
