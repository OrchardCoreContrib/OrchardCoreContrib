﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using OrchardCoreContrib.Data.Migrations;
using YesSql;

namespace OrchardCoreContrib.Data.YesSql.Migrations.Tests;

public class MigrationRunnerTests
{
    [Fact]
    public async Task ShouldRunYesSqlMigrations()
    {
        // Arrange
        var migrationLoader = GetMigrationLoader();
        var session = GetSession();
        var eventHandlers = Enumerable.Empty<IMigrationEventHandler>();
        var migrationRunner = new MigrationRunner(migrationLoader, session, eventHandlers, NullLogger<MigrationRunner>.Instance);

        // Act
        await migrationRunner.MigrateAsync("OrchardCoreContrib.Data.YesSql");

        // Assert
        var migrations = await session.GetAsync<MigrationsHistory>(null);

        Assert.Single(migrations);
        Assert.Single(migrations.Single().Migrations);
    }

    [Fact]
    public async Task SchemaBuilderPropertyShouldBeSetInYesSqlMigration()
    {
        // Arrange
        var migrationLoader = GetMigrationLoader();
        var session = GetSession();

        var migrationEventHandler = new Mock<IMigrationEventHandler>();
        migrationEventHandler
            .Setup(e => e.MigratingAsync(It.IsAny<IMigration>()))
            .Callback<IMigration>(m =>
            {
                // Assert
                var migration = (YesSqlMigration)m;
                Assert.NotNull(migration.SchemaBuilder);
            });
        
        var eventHandlers = new List<IMigrationEventHandler> { migrationEventHandler.Object };

        var migrationRunner = new MigrationRunner(migrationLoader, session, eventHandlers, NullLogger<MigrationRunner>.Instance);

        // Act
        await migrationRunner.MigrateAsync("OrchardCoreContrib.Data.YesSql");
    }

    private static IMigrationLoader GetMigrationLoader()
    {
        var services = new ServiceCollection();

        services.AddScoped<IMigration, Migration>();
        services.AddScoped<IMigrationLoader, MigrationLoader>();

        var serviceProvider = services.BuildServiceProvider();

        return serviceProvider.GetService<IMigrationLoader>();
    }

    private static ISession GetSession()
    {
        var records = new List<object>();
        var session = new Mock<ISession>();
        session
            .Setup(s => s.Save(It.IsAny<object>(), It.IsAny<bool>(), It.IsAny<string>()))
            .Callback<object, bool, string>((obj, _, _) =>
            {
                records.RemoveAll(r => r.GetType() == obj.GetType());
                records.Add(obj);
            });
        session
            .Setup(s => s.GetAsync<MigrationsHistory>(It.IsAny<long[]>(), It.IsAny<string>()))
            .Returns<long[], string>((ids, _) => Task.FromResult(records.OfType<MigrationsHistory>()));
        session
            .Setup(s => s.Query(It.IsAny<string>()))
            .Returns<string>(_ =>
            {
                var query = new Mock<IQuery>();
                query
                    .Setup(q => q.For<MigrationsHistory>(It.IsAny<bool>()))
                    .Returns<bool>(_ =>
                    {
                        var queryOfT = new Mock<IQuery<MigrationsHistory>>();
                        queryOfT
                            .Setup(q => q.FirstOrDefaultAsync())
                            .Returns(() => Task.FromResult(default(MigrationsHistory)));

                        return queryOfT.Object;
                    });

                return query.Object;
            });
        session
            .Setup(s => s.CancelAsync())
            .Returns(async () =>
            {
                records.Clear();

                await Task.CompletedTask;
            });

        return session.Object;
    }
}
