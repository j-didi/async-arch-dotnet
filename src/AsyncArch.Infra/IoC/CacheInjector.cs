using AsyncArch.Infra.Settings;
using Microsoft.Extensions.DependencyInjection;

namespace AsyncArch.Infra.IoC;

internal static class CacheInjector
{
    internal static IServiceCollection InjectCache(
        this IServiceCollection services,
        AppSettings settings
    ) => services.AddDistributedRedisCache(options =>
    {
        options.Configuration = settings.CacheSettings.ConnectionString;
        options.InstanceName = settings.CacheSettings.InstanceName;
    });
}