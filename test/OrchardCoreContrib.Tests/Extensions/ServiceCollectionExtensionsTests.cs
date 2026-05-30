using Microsoft.Extensions.DependencyInjection;
using OrchardCoreContrib.Avatars;

namespace OrchardCoreContrib.Extensions.Tests;

public class ServiceCollectionExtensionsTests
{
    [Fact]
    public void AddOrchardCoreContrib_ThrowsArgumentNullException_WhenServicesIsNull()
    {
        // Arrange
        IServiceCollection services = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => services.AddOrchardCoreContrib());
    }

    [Fact]
    public void AddOrchardCoreContrib_CreatesBuilderAndRegistersDefaultServices()
    {
        // Arrange
        var services = new ServiceCollection();

        // Act
        var builder = services.AddOrchardCoreContrib();

        // Assert
        Assert.NotNull(builder);

        using var provider = services.BuildServiceProvider();

        var timeProvider = provider.GetRequiredService<TimeProvider>();
        var avatarService = provider.GetRequiredService<IAvatarService>();

        Assert.IsType<SystemTimeProvider>(timeProvider);
        Assert.IsType<NullAvatarService>(avatarService);
    }
}
