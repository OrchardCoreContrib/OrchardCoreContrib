namespace OrchardCoreContrib.Data.Migrations;

/// <summary>
/// Represents a base class for the migration.
/// </summary>
public abstract class Migration : IMigration
{
    /// <inheritdoc/>
    public virtual void Down()
    {
    }

    public virtual Task DownAsync()
    {
        Down();

        return Task.CompletedTask;
    }

    /// <inheritdoc/>
    public virtual void Up()
    {
    }

    public virtual Task UpAsync()
    {
        Up();

        return Task.CompletedTask;
    }
}
