using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace AspBoot.Service;

public static class ServiceProvider
{
    public static IServiceCollection AddServices(this IServiceCollection services,
        Assembly assembliesToScan)
    {
        var assembly = assembliesToScan.GetExportedTypes().Where(IsService);
        foreach (var service in assembly)
        {
            services.AddScoped(service);
        }
        return services;
    }

    private static bool IsService(Type c)
    {
        return c.GetCustomAttribute(typeof(ServiceAttribute)) != null;
    }
}
