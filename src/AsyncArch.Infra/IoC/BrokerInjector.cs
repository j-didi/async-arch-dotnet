using AsyncArch.Core.Todos.Create;
using AsyncArch.Infra.Settings;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace AsyncArch.Infra.IoC;

internal static class BrokerInjector
{
    internal static IServiceCollection InjectBroker(
        this IServiceCollection services,
        AppSettings settings
    ) => services.AddMassTransit(e =>
    {
        e.SetKebabCaseEndpointNameFormatter();
        e.AddConsumersFromNamespaceContaining<CreateTodoConsumer>();
        e.UsingRabbitMq((context, config) =>
        {
            config.ClearSerialization();
            config.UseRawJsonSerializer();
            config.Host(
                settings.BrokerSettings.Host, 
                settings.BrokerSettings.VHost,
                rabbitMq => 
                {
                    rabbitMq.Username(settings.BrokerSettings.UserName);
                    rabbitMq.Password(settings.BrokerSettings.Password);
                }
            );
            
            config.ConfigureEndpoints(context);
        });
    });
}