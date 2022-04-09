using AsyncArch.Infra.Settings;
using Microsoft.Extensions.DependencyInjection;

namespace AsyncArch.Infra.IoC;

internal static class SettingsInjector
{
    internal static IServiceCollection InjectSettings(
        this IServiceCollection services,
        AppSettings settings
    ) => services.AddSingleton(settings);
}