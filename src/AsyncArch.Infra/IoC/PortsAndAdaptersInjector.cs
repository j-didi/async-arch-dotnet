using AsyncArch.Core.Ports;
using AsyncArch.Infra.Cache;
using AsyncArch.Infra.Database;
using AsyncArch.Infra.Notifications;
using Microsoft.Extensions.DependencyInjection;

namespace AsyncArch.Infra.IoC;

internal static class PortsAndAdaptersInjector
{
    internal static IServiceCollection InjectPortsAndAdapters(
        this IServiceCollection services
    ) => services
        .AddTransient<ITodosPort, TodosAdapter>()
        .AddTransient<ICachePort, CacheAdapter>()
        .AddTransient<INotificationsPort, NotificationsAdapter>();
}