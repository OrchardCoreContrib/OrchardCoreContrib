using LinqToDB;
using YesSql;

namespace OrchardCoreContrib.Linq.Tests;

public class CustomOrchardCoreDataContext(IStore store) : OrchardCoreDataContext(store)
{
    public ITable<Person> People => GetTable<Person>();
}
