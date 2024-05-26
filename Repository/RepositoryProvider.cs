using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace AspBoot.Repository;

public static class RepositoryProvider
{
    public static IServiceCollection AddRepositories(this IServiceCollection services,
        Assembly assembliesToScan)
    {
        var assembly = assembliesToScan.GetExportedTypes().Where(IsRepository);
        foreach (var service in assembly)
        {
            services.AddScoped(service);
        }
        return services;
    }

    private static bool IsRepository(Type c)
    {
        return c.GetCustomAttribute(typeof(RepositoryAttribute)) != null;
    }
}
