using SkiaSharp;

namespace OrchardCoreContrib.Avatars.Tests;

public class InitialsAvatarProviderTests
{
    [Fact]
    public void GetAvatar_ShouldThrow_WhenContextIsNull()
    {
        // Arrange
        var provider = new InitialsAvatarProvider();

        // Act & Assert
        Assert.ThrowsAny<ArgumentNullException>(() => provider.GetAvatar(null!));
    }

    [Fact]
    public void GetAvatar_ShouldThrow_WhenDisplayNameIsEmpty()
    {
        // Arrange
        var provider = new InitialsAvatarProvider();
        var context = new AvatarContext { DisplayName = string.Empty };

        // Act & Assert
        Assert.ThrowsAny<ArgumentException>(() => provider.GetAvatar(context));
    }

    [Fact]
    public void GetAvatar_ShouldReturn_DataUri_WithValidPng_AndRequestedSize()
    {
        // Arrange
        var provider = new InitialsAvatarProvider();
        var context = new AvatarContext { DisplayName = "John Doe" };

        // Act
        var result = provider.GetAvatar(context, 96);

        // Assert
        Assert.StartsWith("data:image/png;base64,", result);

        var bytes = Convert.FromBase64String(result["data:image/png;base64,".Length..]);
        using var bitmap = SKBitmap.Decode(bytes);

        Assert.NotNull(bitmap);
        Assert.Equal(96, bitmap.Width);
        Assert.Equal(96, bitmap.Height);
    }

    [Fact]
    public void GetAvatar_ShouldUseOnlyFirstTwoNameParts()
    {
        // Arrange
        var provider = new InitialsAvatarProvider();

        // Act
        var a = provider.GetAvatar(new AvatarContext { DisplayName = "John Fitzgerald Kennedy" }, 80);
        var b = provider.GetAvatar(new AvatarContext { DisplayName = "John Foo" }, 80);

        // Assert
        Assert.Equal(a, b); // Both should render "JF"
    }

    [Fact]
    public void GetAvatar_ShouldNormalizeCaseAndSpaces()
    {
        // Arrange
        var provider = new InitialsAvatarProvider();

        // Act
        var a = provider.GetAvatar(new AvatarContext { DisplayName = "john    doe" }, 80);
        var b = provider.GetAvatar(new AvatarContext { DisplayName = "John Doe" }, 80);

        // Assert
        Assert.Equal(a, b); // Both should render "JD"
    }
}
