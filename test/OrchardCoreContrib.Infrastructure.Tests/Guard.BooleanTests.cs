using Xunit;

namespace OrchardCoreContrib.Infrastructure.Tests;

public partial class GuardTests
{
	[Fact]
	public void ArgumentIsFalse_TrueValue_ThrowsArgumentException()
	{
		// Arrange
		var value = true;

		// Act & Assert
		var exception = Assert.Throws<ArgumentException>(() => Guard.ArgumentIsFalse(value));

		Assert.Equal(nameof(value), exception.ParamName);
		Assert.Equal($"Value must be false. (Parameter '{nameof(value)}')", exception.Message);
	}

	[Fact]
	public void ArgumentIsFalse_FalseValue_DoesNotThrow()
	{
		// Act
		Guard.ArgumentIsFalse(false);
	}

    [Fact]
    public void ArgumentIsFalse_DoesNotThrow_WhenFalse()
    {
        // Arrange
        bool? input = false;

        // Act
        Guard.ArgumentIsFalse(input);
    }

    [Fact]
    public void ArgumentIsFalse_ThrowsArgumentException_WhenTrue()
    {
        // Arrange
        bool? input = true;

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => Guard.ArgumentIsFalse(input));

        Assert.Contains("Value must be false.", exception.Message);
        Assert.Equal("input", exception.ParamName);
    }

    [Fact]
    public void ArgumentIsFalse_ThrowsArgumentException_WhenNull()
    {
        // Arrange
        bool? input = null;

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => Guard.ArgumentIsFalse(input));

        Assert.Contains("Value must be false.", exception.Message);
        Assert.Equal("input", exception.ParamName);
    }

    [Fact]
	public void ArgumentIsTrue_FalseValue_ThrowsArgumentException()
	{
		// Arrange
		var value = false;

		// Act & Assert
		var exception = Assert.Throws<ArgumentException>(() => Guard.ArgumentIsTrue(value));

        Assert.Equal(nameof(value), exception.ParamName);
		Assert.Equal($"Value must be true. (Parameter '{nameof(value)}')", exception.Message);
	}

	[Fact]
	public void ArgumentIsTrue_TrueValue_DoesNotThrow()
	{
		// Act
		Guard.ArgumentIsTrue(true);
	}

    [Fact]
    public void ArgumentIsTrue_DoesNotThrow_WhenTrue()
    {
        // Arrange
        bool? input = true;

        // Act
        Guard.ArgumentIsTrue(input);
    }

    [Fact]
    public void ArgumentIsTrue_ThrowsArgumentException_WhenFalse()
    {
		// Arrange
        bool? input = false;

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => Guard.ArgumentIsTrue(input));

        Assert.Contains("Value must be true.", exception.Message);
        Assert.Equal("input", exception.ParamName);
    }

    [Fact]
    public void ArgumentIsTrue_ThrowsArgumentException_WhenNull()
    {
        // Arrange
        bool? input = null;

		// Act & Assert
		var exception = Assert.Throws<ArgumentException>(() => Guard.ArgumentIsTrue(input));

        Assert.Contains("Value must be true.", exception.Message);
        Assert.Equal("input", exception.ParamName);
    }
}
