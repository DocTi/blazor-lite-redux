using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiteRedux
{
    public class TriggerContainer
    {
        private readonly IEnumerable<ITrigger> triggers;

        public TriggerContainer(IEnumerable<ITrigger> triggers)
        {
            this.triggers = triggers;
        }

        public Task HandleActionAsync(object action, IStore store)
        {
            return Task.WhenAll(triggers.Where(x => x.ShouldAction(action)).Select(s => s.HandleAsync(action, store)));
        }
    }
}
