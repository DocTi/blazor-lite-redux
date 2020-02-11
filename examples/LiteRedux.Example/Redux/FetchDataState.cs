using LiteRedux.Example.Data;

namespace LiteRedux.Example.Redux
{
    public class FetchDataState
    {
        public FetchDataState()
        {
            IsLoading = false;
            Data = null;
        }

        public FetchDataState(bool isLoading, WeatherForecast[] data)
        {
            IsLoading = isLoading;
            Data = data;
        }

        public bool IsLoading { get; }
        public WeatherForecast[] Data { get; }
    }
}
