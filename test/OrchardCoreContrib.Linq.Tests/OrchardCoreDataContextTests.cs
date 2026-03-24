using Dapper;
using LinqToDB;
using LinqToDB.Async;
using Xunit;
using YesSql;
using YesSql.Provider.Sqlite;
using YesSql.Sql;

namespace OrchardCoreContrib.Linq.Tests;

public class OrchardCoreDataContextTests
{
    private readonly IStore _store;

    public OrchardCoreDataContextTests()
    {
        _store = StoreFactory.CreateAndInitializeAsync(new Configuration()
            .UseSqLite("Data Source=occ.db;Cache=Shared")).Result;
    }

    [Fact]
    public void SimpleQuery()
    {
        // Arrange
        var dbContext = new OrchardCoreDataContext(_store);

        // Act
        var result = dbContext.AliasPartIndex
            .OrderBy(index => index.Alias)
            .First();

        // Assert
        Assert.Equal("categories", result.Alias);
    }

    [Fact]
    public void ComplexQuery()
    {
        using var dbContext = new OrchardCoreDataContext(_store);
        var result = from ci in dbContext.ContentItemIndex
                     join r in dbContext.AutoroutePartIndex on ci.ContentItemId equals r.ContentItemId
                     where r.Path.StartsWith("tags/", StringComparison.OrdinalIgnoreCase)
                     select ci.DisplayText;

        Assert.NotEmpty(result);
    }

    [Fact]
    public async Task AsyncQuery()
    {
        // Arrange
        var dbContext = new OrchardCoreDataContext(_store);

        // Act
        var result = await dbContext.AliasPartIndex.ToListAsync();

        // Assert
        Assert.Equal(3, result.Count);
    }

    [Fact]
    public async Task QueryFromCustomTable()
    {
        // Arrange
        await using var connection = _store.Configuration.ConnectionFactory.CreateConnection();
        await connection.OpenAsync();

        await using var transaction = await connection.BeginTransactionAsync(_store.Configuration.IsolationLevel);

        var builder = new SchemaBuilder(_store.Configuration, transaction);
        await builder.DropTableAsync("Person");

        await builder.CreateTableAsync("Person", table => table
            .Column<string>("FirstName")
            .Column<string>("LastName")
        );

        await builder.Connection.ExecuteAsync("INSERT INTO Person (FirstName, LastName) VALUES (@FirstName, @LastName)", new { FirstName = "John", LastName = "Doe" });

        var dbContext = new CustomOrchardCoreDataContext(_store);

        await transaction.CommitAsync();

        // Act
        var result = await dbContext.People.ToListAsync();

        // Assert
        Assert.NotNull(result);
        Assert.NotEmpty(result);
    }
}
