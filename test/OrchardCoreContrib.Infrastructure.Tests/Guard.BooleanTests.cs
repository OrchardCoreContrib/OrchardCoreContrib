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
}
