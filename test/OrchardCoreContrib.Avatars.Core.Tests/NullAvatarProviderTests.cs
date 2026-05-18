namespace OrchardCoreContrib.Avatars.Tests;

public class NullAvatarProviderTests
{
    [Fact]
    public void GetAvatar_ShouldReturnEmptyString_WhenContextIsProvided()
    {
        // Arrange
        var provider = new NullAvatarProvider();
        var context = new AvatarContext { DisplayName = "Jane Doe" };

        // Act
        var result = provider.GetAvatar(context, 128);

        // Assert
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void GetAvatar_ShouldReturnEmptyString_WhenContextIsNull()
    {
        // Arrange
        var provider = new NullAvatarProvider();

        // Act
        var result = provider.GetAvatar(null!, 80);

        // Assert
        Assert.Equal(string.Empty, result);
    }
}
