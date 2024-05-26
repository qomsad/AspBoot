using Microsoft.Extensions.Configuration;

namespace AspBoot.Configuration;

public static class Option
{
    public static T GetParam<T>(this IConfiguration configuration)
    {
        return configuration.GetSection(typeof(T).Name).Get<T>() ?? throw new OptionException(typeof(T).Name);
    }
}
