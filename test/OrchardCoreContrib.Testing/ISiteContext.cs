using OrchardCore.Environment.Shell;

namespace OrchardCoreContrib.Testing;

public interface ISiteContext : IDisposable
{
    static IShellHost ShellHost { get; }

    static IShellSettingsManager ShellSettingsManager { get; }

    static HttpClient DefaultTenantClient { get; }

    SiteContextOptions Options { init; get; }

    HttpClient Client { get; }

    string TenantName { get; }

    Task InitializeAsync(string tenantName = null);
}
