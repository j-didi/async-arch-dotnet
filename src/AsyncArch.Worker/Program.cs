using AsyncArch.Infra.Database;
using AsyncArch.Infra.IoC;
using AsyncArch.Infra.Settings;
using AsyncArch.Worker;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        var settings = context.Configuration.Get<AppSettings>();
        services.InjectDependencies(settings);
        services.AddHostedService<Worker>();
    })
    .Build();

await host.ApplyMigrations();
await host.RunAsync();