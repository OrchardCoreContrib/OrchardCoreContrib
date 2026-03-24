using NavigationBuilder = OrchardCore.Navigation.NavigationBuilder;

namespace OrchardCoreContrib.Navigation;

/// <summary>
/// Represents a base class for providing a navigation.
/// </summary>
public abstract class NavigationProvider : INavigationProvider
{
    /// <inheritdoc/>
    public abstract string Name { get; }

    [Obsolete("This method is deprecated, use BuildNavigationAsync instead.", error: true)]
    public virtual void BuildNavigation(NavigationBuilder builder)
    {
    }

    /// <inheritdoc/>
    public virtual Task BuildNavigationAsync(NavigationBuilder builder) => Task.CompletedTask;

    /// <inheritdoc/>
    public async ValueTask BuildNavigationAsync(string name, NavigationBuilder builder)
    {
        if (name.Equals(Name, StringComparison.OrdinalIgnoreCase))
        {
            await BuildNavigationAsync(builder);
        }
        else
        {
            await ValueTask.CompletedTask;
        }
    }
}
