using Microsoft.Extensions.DependencyInjection;
using Moq;
using OrchardCore.Environment.Shell;
using OrchardCore.Environment.Shell.Builders;
using OrchardCore.Environment.Shell.Scope;
using OrchardCore.Settings;
using Xunit;

namespace OrchardCoreContrib.Settings.Tests;

public partial class GlobalSettingsAccessorTests
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

    [Fact]
    public async Task GetSettingsAsync_Throws_When_Default_Tenant_Not_Found()
    {
        // Arrange
        var shellHost = new Mock<IShellHost>();

        shellHost
            .Setup(h => h.TryGetSettings(ShellSettings.DefaultShellName, out It.Ref<ShellSettings>.IsAny))
            .Returns(false);

        var globalSettingsAccessor = new GlobalSettingsAccessor(shellHost.Object);

        // Act & Assert
        var exception = await Assert.ThrowsAsync<InvalidOperationException>(async () => await globalSettingsAccessor.GetSettingsAsync<TestSettings>());

        Assert.Equal("Default tenant not found.", exception.Message);

        shellHost.Verify(h => h.GetScopeAsync(It.IsAny<ShellSettings>()), Times.Never);
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
}
