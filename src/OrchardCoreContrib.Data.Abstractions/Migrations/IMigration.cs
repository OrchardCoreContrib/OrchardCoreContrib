namespace OrchardCoreContrib.Data.Migrations;

/// <summary>
/// Represents a contract for a migration.
/// </summary>
public interface IMigration
{
    /// <summary>
    /// Apply the migration.
    /// </summary>
    void Up();

    /// <summary>
    /// Apply the migration asynchronously.
    /// </summary>
    Task UpAsync();

    /// <summary>
    /// Rollback the migration.
    /// </summary>
    void Down();

    /// <summary>
    /// Rollback the migration asynchronously.
    /// </summary>
    Task DownAsync();
}
