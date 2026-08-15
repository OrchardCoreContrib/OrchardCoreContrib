using Xunit;

namespace OrchardCoreContrib.Infrastructure.Tests;

public partial class GuardTests
{
    [Fact]
    public void ArgumentNotNullOrEmpty_ThrowsArgumentNullException_ForNull()
    {
        // Arrange & Act
        var exception = Assert.Throws<ArgumentNullException>(() => Guard.ArgumentNotNullOrEmpty(null!, "param"));

        // Assert
        Assert.Equal("param", exception.ParamName);
    }

    [Fact]
    public void ArgumentNotNullOrEmpty_ThrowsArgumentException_ForEmpty()
    {
        // Arrange & Act
        var exception = Assert.Throws<ArgumentException>(() => Guard.ArgumentNotNullOrEmpty(string.Empty, "param"));
        Assert.Equal("param", exception.ParamName);
    }

    [Fact]
    public void ArgumentNotNullOrEmpty_DoesNotThrow_ForNonEmpty()
    {
        // Arrange & Act
        var exception = Record.Exception(() => Guard.ArgumentNotNullOrEmpty("value", "param"));
        Assert.Null(exception);
    }

    [Fact]
    public void ArgumentNotNullOrWhiteSpace_ThrowsArgumentNullException_ForNull()
    {
        // Arrange & Act
        var exception = Assert.Throws<ArgumentNullException>(() => Guard.ArgumentNotNullOrWhiteSpace(null!, "param"));
        Assert.Equal("param", exception.ParamName);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void ArgumentNotNullOrWhiteSpace_ThrowsArgumentException_ForEmptyOrWhiteSpace(string value)
    {
        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => Guard.ArgumentNotNullOrWhiteSpace(value, "param"));

        Assert.Equal("param", exception.ParamName);
    }

    [Fact]
    public void ArgumentNotNullOrWhiteSpace_DoesNotThrow_ForNonWhiteSpace()
    {
        // Act & Assert
        var exception = Record.Exception(() => Guard.ArgumentNotNullOrWhiteSpace("a", "param"));

        Assert.Null(exception);
    }

    [Fact]
    public void ArgumentNotEmpty_ThrowsArgumentNullException_ForNull()
    {
        // Act & Assert
        var exception = Assert.Throws<ArgumentNullException>(() => Guard.ArgumentNotEmpty(null!, "param"));

        Assert.Equal("param", exception.ParamName);
    }

    [Fact]
    public void ArgumentNotEmpty_ThrowsArgumentException_ForEmpty()
    {
        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => Guard.ArgumentNotEmpty(string.Empty, "param"));

        Assert.Equal("param", exception.ParamName);
    }

    [Fact]
    public void ArgumentNotEmpty_DoesNotThrow_ForNonEmpty()
    {
        // Act & Assert
        var exception = Record.Exception(() => Guard.ArgumentNotEmpty("ok", "param"));

        Assert.Null(exception);
    }

    [Fact]
    public void ArgumentNotWhiteSpace_ThrowsArgumentNullException_ForNull()
    {
        // Act & Assert
        var exception = Assert.Throws<ArgumentNullException>(() => Guard.ArgumentNotWhiteSpace(null!, "param"));

        Assert.Equal("param", exception.ParamName);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void ArgumentNotWhiteSpace_ThrowsArgumentException_ForEmptyOrWhiteSpace(string value)
    {
        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => Guard.ArgumentNotWhiteSpace(value, "param"));

        Assert.Equal("param", exception.ParamName);
    }

    [Fact]
    public void ArgumentNotWhiteSpace_DoesNotThrow_ForNonWhiteSpace()
    {
        // Act & Assert
        var exception = Record.Exception(() => Guard.ArgumentNotWhiteSpace("ok", "param"));

        Assert.Null(exception);
    }
}
