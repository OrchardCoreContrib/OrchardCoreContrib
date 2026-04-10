namespace OrchardCoreContrib.Testing;

public interface ISiteContext<TSiteStartup> : ISiteContext where TSiteStartup : class
{
    static OrchardCoreWebApplicationFactory<TSiteStartup> Site { get; }
}
