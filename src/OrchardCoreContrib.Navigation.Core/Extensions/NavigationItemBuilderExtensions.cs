using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Environment.Shell;
using OrchardCore.Environment.Shell.Scope;

namespace OrchardCore.Navigation;

/// <summary>
/// Provides extension methods for configuring navigation items based on tenant information.
/// </summary>
public static class NavigationItemBuilderExtensions
{
    private static string CurrentTenant => ShellScope.Current?.ServiceProvider.GetService<ShellSettings>()?.Name;

    /// <summary>
    /// Configures the navigation item for the specified tenant name.
    /// </summary>
    /// <param name="builder">The navigation item builder to configure.</param>
    /// <param name="tenantName">The name of the tenant to associate with the navigation item.</param>
    /// <returns>The same instance of <see cref="NavigationItemBuilder"/> to allow for method chaining.</returns>
    public static NavigationItemBuilder Tenant(this NavigationItemBuilder builder, string tenantName)
    {
        ArgumentException.ThrowIfNullOrEmpty(tenantName);

        if (!tenantName.Equals(CurrentTenant, StringComparison.OrdinalIgnoreCase))
        {
            builder.Url(string.Empty);
        }

        return builder;
    }

    /// <summary>
    /// Configures the navigation item to be visible only for tenants that satisfy the specified predicate.
    /// </summary>
    /// <remarks>If the predicate returns <see langword="false"/> for the current tenant, the navigation item
    /// will be hidden by clearing its action.</remarks>
    /// <param name="builder">The navigation item builder to configure.</param>
    /// <param name="tenantPredicate">A predicate that determines whether the navigation item should be visible for a given tenant. The predicate
    /// receives the current tenant's identifier as a parameter and should return <see langword="true"/> to display the
    /// item; otherwise, <see langword="false"/>.</param>
    /// <returns>The same <see cref="NavigationItemBuilder"/> instance, to allow for method chaining.</returns>
    public static NavigationItemBuilder Tenant(this NavigationItemBuilder builder, Func<string, bool> tenantPredicate)
    {
        ArgumentNullException.ThrowIfNull(tenantPredicate);

        if (!tenantPredicate(CurrentTenant))
        {
            builder.Url(string.Empty);
        }

        return builder;
    }

    /// <summary>
    /// Configures the navigation item for tenants based on the specified tenant names.
    /// </summary>
    /// <param name="builder">The navigation item builder to configure.</param>
    /// <param name="tenantNames">A collection of tenant names to evaluate..</param>
    /// <returns>The configured navigation item builder.</returns>
    public static NavigationItemBuilder Tenants(this NavigationItemBuilder builder, IEnumerable<string> tenantNames)
    {
        ArgumentNullException.ThrowIfNull(tenantNames);

        if (!tenantNames.Contains(CurrentTenant, StringComparer.OrdinalIgnoreCase))
        {
            builder.Url(string.Empty);
        }

        return builder;
    }
}
