using LiteRedux.Example.Data;
using System.Threading.Tasks;

namespace LiteRedux.Example.Redux
{
    public class FetchTrigger : Trigger<FetchAction>
    {
        private readonly WeatherForecastService weatherForecastService;

        public FetchTrigger(WeatherForecastService weatherForecastService)
        {
            this.weatherForecastService = weatherForecastService;
        }

        protected async override Task HandleAsync(FetchAction action, IStore store)
        {
            WeatherForecast[] data = await weatherForecastService.GetForecastAsync(action.Date);

            store.Dispatch(new CompleteFetchAction(data));
        }
    }
}
