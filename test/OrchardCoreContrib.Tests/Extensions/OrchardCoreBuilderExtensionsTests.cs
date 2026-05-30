using Microsoft.Extensions.DependencyInjection;
using OrchardCoreContrib.Avatars;

namespace OrchardCoreContrib.Extensions.Tests;

public class OrchardCoreBuilderExtensionsTests
{
    [Fact]
    public void AddOrchardCoreContrib_ThrowsArgumentNullException_WhenServicesIsNull()
    {
        // Arrange
        OrchardCoreBuilder builder = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => builder.AddOrchardCoreContrib());
    }

    [Fact]
    public void AddOrchardCoreContrib_CreatesBuilderAndRegistersDefaultServices()
    {
        // Arrange
        var services = new ServiceCollection();
        var builder = new OrchardCoreBuilder(services);

        // Act
        builder = builder.AddOrchardCoreContrib();

        // Assert
        Assert.NotNull(builder);

        using var provider = services.BuildServiceProvider();

        var timeProvider = provider.GetRequiredService<TimeProvider>();
        var avatarService = provider.GetRequiredService<IAvatarService>();

        Assert.IsType<SystemTimeProvider>(timeProvider);
        Assert.IsType<NullAvatarService>(avatarService);
    }
}
