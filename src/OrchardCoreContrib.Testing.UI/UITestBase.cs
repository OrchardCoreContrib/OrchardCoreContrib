using OrchardCoreContrib.Testing.UI.Infrastructure;

namespace OrchardCoreContrib.Testing.UI;

/// <summary>
/// Represents a base class for UI testing.
/// </summary>
/// <typeparam name="TStartup">The startup class that will be used as entry point.</typeparam>
/// <param name="fixture">The <see cref="WebApplicationFactoryFixture{TStartup}"/>.</param>
public abstract class UITestBase<TStartup>(WebApplicationFactoryFixture<TStartup> fixture) where TStartup : class
{
    /// <summary>
    /// Gets the base URL used for the tested website.
    /// </summary>
    public string BaseUrl => fixture.ServerAddress;
}
