using LinqToDB;
using LinqToDB.Data;
using OrchardCoreContrib.Infrastructure;
using YesSql;

namespace OrchardCoreContrib.Linq;

internal class OrchardCoreDataConnectionFactory
{
    public static DataConnection Create(IStore store)
    {
        Guard.ArgumentNotNull(store);

        using var connection = store.Configuration.ConnectionFactory.CreateConnection();

        var providerName = GetDatabaseProviderName(store.Configuration.SqlDialect.Name);

        return new DataConnection(new DataOptions().UseConnectionString(providerName, connection.ConnectionString));
    }

    private static string GetDatabaseProviderName(string dialectName) =>
        dialectName switch
        {
            "SqlServer" => "MicrosoftDataSqlClient",
            "Sqlite" => ProviderName.SQLite,
            "MySql" => ProviderName.MySql,
            "PostgreSql" => ProviderName.PostgreSQL,
            _ => throw new NotSupportedException("The provider name is not supported."),
        };
}
