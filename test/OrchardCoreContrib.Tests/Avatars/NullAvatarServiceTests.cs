namespace OrchardCoreContrib.Avatars.Tests;

public class NullAvatarServiceTests
{
    [Fact]
    public void GetAvatar_ShouldReturnEmptyString_WhenContextIsProvided()
    {
        // Arrange
        var provider = new NullAvatarService();
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
        var provider = new NullAvatarService();

        // Act
        var result = provider.GetAvatar(null!, 80);

        // Assert
        Assert.Equal(string.Empty, result);
    }
}
