using AsyncArch.Infra.Settings;
using Microsoft.Extensions.DependencyInjection;

namespace AsyncArch.Infra.IoC;

public static class Injector
{
    public static void InjectDependencies(
        this IServiceCollection services,
        AppSettings settings
    ) => services
        .InjectPortsAndAdapters()
        .InjectBroker(settings)
        .InjectSettings(settings)
        .InjectDatabase(settings)
        .InjectCache(settings);
}