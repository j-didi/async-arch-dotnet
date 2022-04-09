using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AsyncArch.Infra.Database;

public static class MigrationsExtensions
{
    public static async Task ApplyMigrations(this IHost host)
    {
        using var scope = host.Services.CreateScope();
        var context = scope.ServiceProvider.GetService<DatabaseContext>()!;
        await context.Database.MigrateAsync();
    }
}