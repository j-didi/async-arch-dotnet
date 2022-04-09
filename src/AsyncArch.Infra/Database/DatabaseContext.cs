﻿using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace AsyncArch.Infra.Database;

public class DatabaseContext: DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options):
        base(options) {}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        var type = GetType();
        var assembly = Assembly.GetAssembly(type);
        builder.ApplyConfigurationsFromAssembly(assembly!);
        base.OnModelCreating(builder);
    }
}