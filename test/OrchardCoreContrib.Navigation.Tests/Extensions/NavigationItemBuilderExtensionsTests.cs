using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Navigation;
using System.Security.Claims;

namespace OrchardCoreContrib.Navigation.Tests.Extensions;

public class NavigationItemBuilderExtensionsTests
{
    [Fact]
    public async Task Tenant_ShouldHideMenuItem_IfGivenTenantNotMatchesCurrentTenant()
    {
        // Arrange
        var builder = new NavigationItemBuilder();
        var context = new BlogSiteContext();

        await context.InitializeAsync();

        // Act & Assert
        await context.UsingTenantScopeAsync(async scope =>
        {
            var actionContext = GetActionContext(scope.ServiceProvider);

            var navigationMananger = scope.ServiceProvider.GetService<INavigationManager>();

            var menuItems = await navigationMananger.BuildMenuAsync(nameof(TestMenu1), actionContext);

            Assert.Empty(menuItems);
        });
    }

    [Fact]
    public async Task Tenant_ShouldShowMenuItem_IfGivenTenantMatchesCurrentTenant()
    {
        // Arrange
        var builder = new NavigationItemBuilder();
        var context = new BlogSiteContext();

        await context.InitializeAsync("TestTenant");

        // Act & Assert
        await context.UsingTenantScopeAsync(async scope =>
        {
            var actionContext = GetActionContext(scope.ServiceProvider);

            var navigationMananger = scope.ServiceProvider.GetService<INavigationManager>();

            var menuItems = await navigationMananger.BuildMenuAsync(nameof(TestMenu1), actionContext);

            Assert.NotEmpty(menuItems);
        });
    }

    [Theory]
    [InlineData("TestTenant1", true)]
    [InlineData("TestTenant2", true)]
    [InlineData("Tenant1", false)]
    [InlineData("Tenant2", false)]
    public async Task Tenant_ShouldShowMenuItem_IfCurrentTenantMatchesGivenPredicate(string tenant, bool show)
    {
        // Arrange
        var builder = new NavigationItemBuilder();
        var context = new BlogSiteContext();

        await context.InitializeAsync(tenant);

        // Act & Assert
        await context.UsingTenantScopeAsync(async scope =>
        {
            var actionContext = GetActionContext(scope.ServiceProvider);

            var navigationMananger = scope.ServiceProvider.GetService<INavigationManager>();

            var menuItems = await navigationMananger.BuildMenuAsync(nameof(TestMenu2), actionContext);

            Assert.Equal(show, menuItems.Any());
        });
    }

    [Theory]
    [InlineData("TestTenant1", true)]
    [InlineData("TestTenant2", true)]
    [InlineData("TestTenant3", false)]
    public async Task Tenants_ShouldShowMenuItem_IfCurrentTenantMatchesOneOfTheGivenTenants(string tenant, bool show)
    {
        // Arrange
        var builder = new NavigationItemBuilder();
        var context = new BlogSiteContext();

        await context.InitializeAsync(tenant);

        // Act & Assert
        await context.UsingTenantScopeAsync(async scope =>
        {
            var actionContext = GetActionContext(scope.ServiceProvider);

            var navigationMananger = scope.ServiceProvider.GetService<INavigationManager>();

            var menuItems = await navigationMananger.BuildMenuAsync(nameof(TestMenu3), actionContext);

            Assert.Equal(show, menuItems.Any());
        });
    }

    private static ActionContext GetActionContext(IServiceProvider serviceProvider)
    {
        var routeData = new RouteData();

        routeData.Routers.Add(new RouteCollection());

        var actionContext = new ActionContext()
        {
            HttpContext = new DefaultHttpContext
            {
                User = new ClaimsPrincipal(new ClaimsIdentity([new Claim(ClaimTypes.Name, "Test")])),
                RequestServices = serviceProvider
            },
            ActionDescriptor = new ActionDescriptor(),
            RouteData = routeData
        };

        return actionContext;
    }
}
