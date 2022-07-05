using Microsoft.Extensions.DependencyInjection;
using PackIT.Abstraction.Commands;
using System.Reflection;

namespace PackIT.Shared.Commands;

public static class Extensions
{
    public static IServiceCollection AddCommand(this IServiceCollection services)
    {
        var assembly = Assembly.GetCallingAssembly();
        services.AddSingleton<ICommandDispatcher, InMemoryCommandDispatcher>();
        services.Scan(s => s.FromAssemblies(assembly)
            .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());
        return services;
    }
}
