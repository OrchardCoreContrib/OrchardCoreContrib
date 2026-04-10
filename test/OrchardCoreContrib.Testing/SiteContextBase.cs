using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.BackgroundTasks;
using OrchardCore.Environment.Shell;
using OrchardCore.Environment.Shell.Scope;
using OrchardCore.Tenants.ViewModels;
using OrchardCoreContrib.Testing.Security;
using System.Net.Http.Json;

namespace OrchardCoreContrib.Testing;

public abstract class SiteContextBase<TEntryPoint> : ISiteContext<TEntryPoint> where TEntryPoint : class
{
    static SiteContextBase()
    {
        Site = new OrchardCoreWebApplicationFactory<TEntryPoint>();
        ShellHost = Site.Services.GetRequiredService<IShellHost>();
        ShellSettingsManager = Site.Services.GetRequiredService<IShellSettingsManager>();
        HttpContextAccessor = Site.Services.GetRequiredService<IHttpContextAccessor>();
        DefaultTenantClient = Site.CreateDefaultClient();
    }

    public SiteContextBase()
    {
        Options = new SiteContextOptions();
    }

    public static OrchardCoreWebApplicationFactory<TEntryPoint> Site { get; }

    public static IShellHost ShellHost { get; private set; }

    public static IShellSettingsManager ShellSettingsManager { get; private set; }

    public static IHttpContextAccessor HttpContextAccessor { get; }

    public static HttpClient DefaultTenantClient { get; }

    public SiteContextOptions Options { init; get; }

    public HttpClient Client { get; private set; }

    public string TenantName { get; private set; }

    public virtual async Task InitializeAsync(string tenantName = null)
    {
        tenantName ??= Guid.NewGuid().ToString("n");

        var response = await CreateSiteAsync(tenantName);

        var content = await response.Content.ReadAsStringAsync();

        await SetupSiteAsync(tenantName);

        lock (Site)
        {
            var url = new Uri(content.Trim('"'));
            url = new Uri(url.Scheme + "://" + url.Authority + url.LocalPath + "/");

            Client = Site.CreateDefaultClient(url);

            TenantName = tenantName;
        }

        if (Options.PermissionsContext is not null)
        {
            var permissionContextKey = Guid.NewGuid().ToString();

            SiteContextOptions.PermissionsContexts.TryAdd(permissionContextKey, Options.PermissionsContext);

            Client.DefaultRequestHeaders.Add(nameof(PermissionsContext), permissionContextKey);
        }
    }

    public void Dispose() => Client?.Dispose();

    private async Task<HttpResponseMessage> CreateSiteAsync(string tenantName)
    {
        var model = new CreateApiViewModel
        {
            DatabaseProvider = Options.DatabaseProvider,
            TablePrefix = Options.TablePrefix,
            ConnectionString = Options.ConnectionString,
            RecipeName = Options.RecipeName,
            Name = tenantName,
            RequestUrlPrefix = tenantName
        };

        var result = await DefaultTenantClient.PostAsJsonAsync("api/tenants/create", model);

        result.EnsureSuccessStatusCode();

        return result;
    }

    private async Task SetupSiteAsync(string tenantName)
    {
        var model = new SetupApiViewModel
        {
            SiteName = Options.SiteName,
            DatabaseProvider = Options.DatabaseProvider,
            TablePrefix = Options.TablePrefix,
            ConnectionString = Options.ConnectionString,
            RecipeName = Options.RecipeName,
            UserName = Options.Username,
            Password = Options.Password,
            Name = tenantName,
            Email = Options.Email
        };

        var result = await DefaultTenantClient.PostAsJsonAsync("api/tenants/setup", model);

        result.EnsureSuccessStatusCode();
    }

    public async Task UsingTenantScopeAsync(Func<ShellScope, Task> execute, bool activateShell = true)
    {
        var shellScope = await ShellHost.GetScopeAsync(TenantName);

        HttpContextAccessor.HttpContext = shellScope.ShellContext.CreateHttpContext();

        await shellScope.UsingAsync(execute, activateShell);

        HttpContextAccessor.HttpContext = null;
    }
}
