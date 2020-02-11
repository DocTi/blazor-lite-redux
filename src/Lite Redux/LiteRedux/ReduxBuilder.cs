using LiteRedux;

namespace Microsoft.Extensions.DependencyInjection
{
    public class ReduxBuilder
    {
        private readonly IServiceCollection services;

        internal ReduxBuilder(IServiceCollection services)
        {
            this.services = services;
        }

        public ReduxBuilder AddState<TState>() where TState : class, new()
        {
            services.AddScoped<StateMapper<TState>>();
            services.AddScoped<IStateMapper>(provider => provider.GetService<StateMapper<TState>>());
            services.AddScoped<IStateMapper<TState>>(provider => provider.GetService<StateMapper<TState>>());

            return this;
        }
    }
}
