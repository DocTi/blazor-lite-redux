using LiteRedux.Example.Data;

namespace LiteRedux.Example.Redux
{
    public class CompleteFetchAction
    {
        public CompleteFetchAction(WeatherForecast[] data)
        {
            Data = data;
        }

        public WeatherForecast[] Data { get; }
    }
}
