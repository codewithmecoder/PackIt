using Microsoft.Extensions.DependencyInjection;
using PackIT.Domain.Factories;
using PackIT.Domain.Policies;
using PackIT.Shared.Commands;

namespace PackIT.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddCommand();
        services.AddSingleton<IPackingListFactory, PackingListFactory>();

        services.Scan(s => s.FromAssemblies(typeof(IPackingItemsPolicy).Assembly)
            .AddClasses(c => c.AssignableTo(typeof(IPackingItemsPolicy)))
            .AsImplementedInterfaces()
            .WithSingletonLifetime());
        return services;
    }
}
