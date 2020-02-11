using LiteRedux;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static ReduxBuilder AddLiteRedux(this IServiceCollection services, Assembly assembly)
        {
            services.AddScoped<IStore, Store>();
            services.AddScoped(typeof(IState<>), typeof(State<>));

            services.AddScoped<StateMapperContainer>();
            services.AddScoped<TriggerContainer>();

            services.Scan(assembly);

            return new ReduxBuilder(services);
        }

        private static void Scan(this IServiceCollection services, Assembly assembly)
        {
            var types = assembly.DefinedTypes.Where(x => !x.IsAbstract);

            services.ScanReducers(types);
            services.ScanTriggers(types);
        }

        private static void ScanReducers(this IServiceCollection services, IEnumerable<TypeInfo> types)
        {
            IEnumerable<TypeInfo> reducers = types.Where(x => x.ImplementsGenericInterface(typeof(IReducer<>)));
            foreach (var reducer in reducers)
            {
                services.AddScoped(typeof(IReducer<>).MakeGenericType(reducer.GenericTypeArgumentsInterface(typeof(IReducer<>))), reducer);
            }
        }

        private static void ScanTriggers(this IServiceCollection services, IEnumerable<TypeInfo> types)
        {
            IEnumerable<TypeInfo> triggers = types.Where(x => x.ImplementsGenericInterface(typeof(ITrigger)));
            foreach (var trigger in triggers)
            {
                services.AddScoped(typeof(ITrigger), trigger);
            }
        }

        private static bool ImplementsGenericInterface(this Type type, Type interfaceType)
        {
            return type.IsGenericType(interfaceType) || type.GetTypeInfo().ImplementedInterfaces.Any(i => i.IsGenericType(interfaceType));
        }

        private static bool IsGenericType(this Type type, Type genericType)
        {
            return type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition() == genericType;
        }

        private static Type[] GenericTypeArgumentsInterface(this Type type, Type interfaceType)
        {
            return type.GetTypeInfo().ImplementedInterfaces.First(x => x.IsGenericType(interfaceType)).GenericTypeArguments;
        }
    }
}
