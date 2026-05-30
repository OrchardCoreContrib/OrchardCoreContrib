namespace OrchardCoreContrib.Tests;

public class SystemTimeProviderTests
{
    [Fact]
    public void SystemTimeProvider_IsSealed()
    {
        Assert.True(typeof(SystemTimeProvider).IsSealed);
    }

    [Fact]
    public void SystemTimeProvider_InheritsTimeProvider()
    {
        Assert.True(typeof(TimeProvider).IsAssignableFrom(typeof(SystemTimeProvider)));
    }

    [Fact]
    public void GetUtcNow_ReturnsCurrentUtcTime()
    {
        // Arrange
        var provider = new SystemTimeProvider();
        var before = DateTimeOffset.UtcNow;

        // Act
        var value = provider.GetUtcNow();

        // Assert
        var after = DateTimeOffset.UtcNow;
        Assert.InRange(value, before.AddSeconds(-1), after.AddSeconds(1));
    }
}
