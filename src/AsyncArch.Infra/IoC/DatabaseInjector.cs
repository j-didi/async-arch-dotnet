using AsyncArch.Infra.Database;
using AsyncArch.Infra.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AsyncArch.Infra.IoC;

internal static class DatabaseInjector
{
    public static IServiceCollection InjectDatabase(
        this IServiceCollection services,
        AppSettings settings
    ) => services.AddDbContext<DatabaseContext>(e =>
        e.UseNpgsql(settings.ConnectionString)
            .ConfigureWarnings(x => x.Ignore(CoreEventId.SensitiveDataLoggingEnabledWarning))
            .LogTo(
                Console.WriteLine,
                new[]
                {
                    DbLoggerCategory.Database.Command.Name
                },
                LogLevel.Information,
                DbContextLoggerOptions.DefaultWithLocalTime |
                DbContextLoggerOptions.SingleLine)
            .EnableSensitiveDataLogging()
    );
}