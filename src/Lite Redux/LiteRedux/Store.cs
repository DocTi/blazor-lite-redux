using System.Collections.Generic;

namespace LiteRedux
{
    public class Store : IStore
    {
        private readonly StateMapperContainer stateMappersContainer;
        private readonly TriggerContainer triggerContainer;
        private readonly Queue<object> actionsQueue;

        public Store(StateMapperContainer stateMappersContainer, TriggerContainer triggerContainer)
        {
            this.stateMappersContainer = stateMappersContainer;
            this.triggerContainer = triggerContainer;

            actionsQueue = new Queue<object>();
        }

        public void Dispatch(object action)
        {
            bool dispatching = actionsQueue.Count > 0;
            actionsQueue.Enqueue(action);

            if (!dispatching)
            {
                DequeueActions();
            }
        }

        private void DequeueActions()
        {
            while (actionsQueue.Count != 0)
            {
                ProcessingAction(actionsQueue.Dequeue());
            }
        }

        private void ProcessingAction(object action)
        {
            stateMappersContainer.HandleAction(action);
            triggerContainer.HandleActionAsync(action, this);
        }
    }
}
