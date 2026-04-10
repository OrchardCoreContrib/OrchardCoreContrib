using OrchardCoreContrib.Testing.Security;
using System.Collections.Concurrent;

namespace OrchardCoreContrib.Testing;

public class SiteContextOptions
{
    static SiteContextOptions()
    {
        PermissionsContexts = new();
    }

    public static ConcurrentDictionary<string, PermissionsContext> PermissionsContexts { get; set; }

    public string SiteName { get; set; } = SiteContextOptionDefaults.SiteName;

    public string Username { get; set; } = SiteContextOptionDefaults.Username;

    public string Password { get; set; } = SiteContextOptionDefaults.Password;

    public string Email { get; set; } = SiteContextOptionDefaults.Email;

    public string RecipeName { get; set; } = SiteContextOptionDefaults.RecipeName;

    public string DatabaseProvider { get; set; } = SiteContextOptionDefaults.DatabaseProvider;

    public string ConnectionString { get; set; }

    public string TablePrefix { get; set; }

    public PermissionsContext PermissionsContext { get; set; }
}
