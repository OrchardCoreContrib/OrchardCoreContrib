﻿using Microsoft.Extensions.Logging;
using OrchardCore.Modules;
using OrchardCoreContrib.Data.Migrations;
using YesSql;

namespace OrchardCoreContrib.Data.YesSql.Migrations;

public class YesSqlMigrationRunner : IMigrationRunner
{
    private readonly MigrationDictionary _migrations;
    private readonly IMigrationsHistory _migrationsHistory;
    private readonly ISession _session;
    private readonly IEnumerable<IMigrationEventHandler> _migrationEventHandlers;
    private readonly ILogger<YesSqlMigrationRunner> _logger;

    public YesSqlMigrationRunner(
        IMigrationLoader migrationLoader,
        IMigrationsHistory migrationsHistory,
        ISession session,
        IEnumerable<IMigrationEventHandler> migrationEventHandlers,
        ILogger<YesSqlMigrationRunner> logger)
    {
        _migrationsHistory = migrationsHistory;
        _session = session;
        _migrationEventHandlers = migrationEventHandlers;
        _logger = logger;

        _migrations = migrationLoader.LoadMigrations();
    }

    public async Task MigrateAsync(string moduleId, long targetMigrationId = 0)
    {
        var pendingMigrations = await GetPendingMigrationsAsync();

        foreach (var migrationRecord in pendingMigrations[moduleId])
        {
            var migrationClass = migrationRecord.Migration.GetMigrationClass();

            if (migrationRecord.Skip)
            {
                _logger.LogWarning("Skipping the migration '{migration}'.", migrationClass);

                continue;
            }

            _migrationsHistory.DataMigrationRecord.DataMigrations.Add(new MigrationsHistoryRow
            {
                Id = migrationRecord.Id,
                DataMigrationClass = migrationClass
            });

            try
            {
                _logger.LogInformation("Running the migration '{migration}'.", migrationClass);

                await _migrationEventHandlers.InvokeAsync((handler, migration)
                    => handler.MigratingAsync(migration), migrationRecord.Migration, _logger);

                migrationRecord.Migration.Up();

                await _migrationEventHandlers.InvokeAsync((handler, migration)
                    => handler.MigratedAsync(migration), migrationRecord.Migration, _logger);
            }
            catch
            {
                await _session.CancelAsync();
            }
            finally
            {
                await _session.SaveAsync(_migrationsHistory.DataMigrationRecord);
            }

            if (migrationRecord.Id == targetMigrationId)
            {
                break;
            }
        }
    }

    public async Task RollbackAsync(string moduleId, long targetMigrationId = 0)
    {
        var appliedMigrations = (await _migrationsHistory.GetAppliedMigrationsAsync())
            .Where(m => m.DataMigrationClass.StartsWith(moduleId))
            .Reverse();

        foreach (var migrationRow in appliedMigrations)
        {
            var migrationRecord = _migrations
                .SingleOrDefault(m => m.Migration.GetType().FullName.Equals(migrationRow.DataMigrationClass));

            if (migrationRecord != null)
            {
                try
                {
                    _logger.LogInformation("Rolling back the migration '{migration}'.", migrationRow.DataMigrationClass);

                    await _migrationEventHandlers.InvokeAsync((handler, migration)
                        => handler.RollbackingAsync(migration), migrationRecord.Migration, _logger);

                    migrationRecord.Migration.Down();

                    await _migrationEventHandlers.InvokeAsync((handler, migration)
                        => handler.RollbackedAsync(migration), migrationRecord.Migration, _logger);

                    _migrationsHistory.DataMigrationRecord.DataMigrations.Remove(migrationRow);
                }
                catch
                {
                    await _session.CancelAsync();
                }
                finally
                {
                    await _session.SaveAsync(_migrationsHistory.DataMigrationRecord);
                }

                if (migrationRecord.Id == targetMigrationId)
                {
                    break;
                }
            }
        }
    }

    private async Task<MigrationDictionary> GetPendingMigrationsAsync()
    {
        var migrations = new MigrationDictionary();

        var appliedMigrations = await _migrationsHistory.GetAppliedMigrationsAsync();

        var hasAppliedMigrations = appliedMigrations.Any();
        
        foreach (var migrationRecord in _migrations)
        {
            if (!hasAppliedMigrations || !appliedMigrations.Any(m => m.DataMigrationClass.Equals(migrationRecord.Migration.GetType().FullName)))
            {
                var moduleId = migrationRecord.Migration.GetMigrationModuleId();

                migrations.Add(moduleId, migrationRecord);
            }
        }

        return migrations;
    }
}
