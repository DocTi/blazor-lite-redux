using System;

namespace LiteRedux.Example.Redux
{
    public class FetchAction
    {
        public FetchAction(DateTime date)
        {
            Date = date;
        }

        public DateTime Date { get; }
    }
}
