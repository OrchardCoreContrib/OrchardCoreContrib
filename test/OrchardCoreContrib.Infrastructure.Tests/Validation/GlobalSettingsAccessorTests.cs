using Microsoft.Extensions.DependencyInjection;
using Moq;
using OrchardCore.Environment.Shell;
using OrchardCore.Environment.Shell.Builders;
using OrchardCore.Environment.Shell.Scope;
using OrchardCore.Settings;
using OrchardCoreContrib.Settings;
using Xunit;

namespace OrchardCoreContrib.Infrastructure.Tests.Validation;

public class GlobalSettingsAccessorTests
{
    private static readonly IShellHost _shellHost = GetShellHost();

    [Theory]
    [InlineData(ShellSettings.DefaultShellName)]
    [InlineData("OtherTenant")]
    public async Task GetSettingsAsync_Uses_Default_Tenant(string tenant)
    {
        // Arrange
        var shellScope = await _shellHost.GetScopeAsync(tenant);

        var globalSettingsAccessor = shellScope.ServiceProvider.GetService<IGlobalSettingsAccessor>();

        // Act
        var settings = await globalSettingsAccessor.GetSettingsAsync<TestSettings>();

        // Assert
        Assert.Equal("Default Tenant", settings.Name);
    }

    private static IShellHost GetShellHost()
    {
        var shellHost = new Mock<IShellHost>();

        shellHost
            .Setup(h => h.TryGetSettings(It.IsAny<string>(), out It.Ref<ShellSettings>.IsAny))
            .Callback((string name, out ShellSettings shellSettings) =>
            {
                shellSettings = name == ShellSettings.DefaultShellName
                    ? new ShellSettings { Name = ShellSettings.DefaultShellName }
                    : new ShellSettings { Name = "OtherTenant" };
            })
            .Returns(true);

        shellHost
            .Setup(h => h.GetScopeAsync(It.IsAny<ShellSettings>()))
            .Returns<ShellSettings>(s =>
            {
                var shellContext = new ShellContext
                {
                    ServiceProvider = GetTenantServiceProvider(s.Name),
                };

                return Task.FromResult(new ShellScope(shellContext));
            });

        return shellHost.Object;
    }

    private static ServiceProvider GetTenantServiceProvider(string tenantName)
    {
        var siteService = new Mock<ISiteService>();
        siteService
            .Setup(s => s.GetSiteSettingsAsync())
            .ReturnsAsync(() =>
            {
                var settings = tenantName == ShellSettings.DefaultShellName
                    ? new TestSettings { Name = "Default Tenant" }
                    : new TestSettings { Name = "Other Tenant" };

                return GetSite(settings);
            });

        var services = new ServiceCollection()
            .AddSingleton(_shellHost)
            .AddSingleton(siteService.Object)
            .AddScoped<IGlobalSettingsAccessor, GlobalSettingsAccessor>();

        return services.BuildServiceProvider();
    }

    private static ISite GetSite<T>(T obj) where T : new()
    {
        var mockSite = new Mock<ISite>();

        mockSite.Setup(s => s.As<T>())
            .Returns(obj);

        return mockSite.Object;
    }

    public class TestSettings
    {
        public string Name { get; set; }
    }
}
