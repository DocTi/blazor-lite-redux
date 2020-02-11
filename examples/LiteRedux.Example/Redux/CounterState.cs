namespace LiteRedux.Example.Redux
{
    public class CounterState
    {
        public CounterState()
        {
            Value = 0;
        }

        public CounterState(int value)
        {
            Value = value;
        }

        public int Value { get; }
    }
}
