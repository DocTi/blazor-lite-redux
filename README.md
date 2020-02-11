# Lite Redux
![](/docs/images/logo.png)

Lite Redux is a simple library that implements state management in the Redux-style

## Installing
You should install [LiteRedux with NuGet:](https://www.nuget.org/packages/LiteRedux/0.1.0)
```
Install-Package LiteRedux
```

## Getting started
[Example project](https://github.com/DocTi/blazor-lite-redux/tree/master/examples/LiteRedux.Example)

1. Register a dependency
```c#
services.AddLiteRedux(typeof(CounterState).Assembly);
```
2. Add state
```c#
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
```
```c#
services.AddLiteRedux(typeof(CounterState).Assembly).AddState<CounterState>();
```
3. Add action and reducer
```c#
public class IncrementAction
{
  public IncrementAction() { }
}
```
```c#
public class IncrementActionReducer : Reducer<CounterState, IncrementAction>
{
  protected override CounterState Reduce(CounterState state, IncrementAction action)
  {
    return new CounterState(state.Value + 1);
  }
}
```

### Redux component
Inherit `ReduxComponent` to access the state and store.
```c#
@inherits ReduxComponent<CounterState>
```
1. Getting a state
```c#
@inherits ReduxComponent<CounterState>

<h1>Counter</h1>

<p>Current count: @State.Value.Value</p>
```
2. Dispatching actions
```c#
private void IncrementCount()
{
  Store.Dispatch(new IncrementAction());
}
```

### Trigger
To perform asynchronous operations, such as loading from a database, you can use Trigger
```c#
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
```

## Is coming
1. Unit tests
2. Redux devtools
