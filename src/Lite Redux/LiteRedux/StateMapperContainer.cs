using System.Collections.Generic;

namespace LiteRedux
{
    public class StateMapperContainer
    {
        private readonly IEnumerable<IStateMapper> mappers;

        public StateMapperContainer(IEnumerable<IStateMapper> mappers)
        {
            this.mappers = mappers;
        }

        public void HandleAction(object action)
        {
            foreach (var mapper in mappers)
            {
                mapper.ReduceAction(action);
            }
        }
    }
}
