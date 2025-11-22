
using OrchardCore.Navigation;

namespace OrchardCoreContrib.Navigation.Tests;

public class AdminNavigationProviderTests
{
    [Fact]
    public void AdminNavigationProviderShouldHasAdminAsName()
    {
        // Arrange
        var navigationProvider = new MyAdminMenu();

        // Act & Assert
        Assert.Equal("Admin", navigationProvider.Name);
    }

    [Fact]
    public async Task AdminNavigationProviderShouldExecutesBuildNavigationAsync()
    {
        // Arrange
        var navigationBuilder = new NavigationBuilder();
        var adminMenu = new MyAdminMenu();

        // Act
        await adminMenu.BuildNavigationAsync(navigationBuilder);

        // Assert
        Assert.True(adminMenu.Executed);
    }

    internal class MyAdminMenu : AdminNavigationProvider
    {
        public bool Executed { get; private set; }

        public override Task BuildNavigationAsync(NavigationBuilder builder)
        {
            Executed = true;

            return Task.CompletedTask;
        }
    }
}
