using Xunit;

namespace OrchardCoreContrib.Infrastructure.Tests;

public partial class GuardTests
{
	[Fact]
	public void ArgumentIsNullOrEmpty_NullValue_DoesNotThrow()
	{
		// Arrange
		string value = null;

		// Act
		Guard.ArgumentIsNullOrEmpty(value);
	}

	[Fact]
	public void ArgumentIsNullOrEmpty_EmptyValue_DoesNotThrow()
	{
		// Arrange
		var value = string.Empty;

		// Act
		Guard.ArgumentIsNullOrEmpty(value);
	}

	[Fact]
	public void ArgumentIsNullOrEmpty_NonEmptyValue_ThrowsArgumentNullOrEmptyException()
	{
		// Arrange
		var value = "abc";

		// Act & Assert
		var exception = Assert.Throws<ArgumentNullOrEmptyException>(() => Guard.ArgumentIsNullOrEmpty(value));

		Assert.Equal(nameof(value), exception.ParamName);
	}

	[Theory]
	[InlineData(null)]
	[InlineData("")]
	public void ArgumentNotNullOrEmpty_NullOrEmptyValue_ThrowsArgumentNullOrEmptyException(string value)
	{
        // Act & Assert
        var exception = Assert.Throws<ArgumentNullOrEmptyException>(() => Guard.ArgumentNotNullOrEmpty(value));

		Assert.Equal(nameof(value), exception.ParamName);
	}

	[Fact]
	public void ArgumentNotNullOrEmpty_NonEmptyValue_DoesNotThrow()
	{
		// Arrange
		var value = "abc";

		// act
		Guard.ArgumentNotNullOrEmpty(value);
	}

	[Fact]
    public void ArgumentIsNotNullOrWhiteSpace_NullValue_ThrowsArgumentNullException()
    {
		// Arrange
        string value = null;

		// Act & Assert
		var exception = Assert.Throws<ArgumentNullException>(() => Guard.ArgumentIsNotNullOrWhiteSpace(value));

		Assert.Equal(nameof(value), exception.ParamName);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void ArgumentIsNotNullOrWhiteSpace_WhiteSpaceValue_ThrowsArgumentNullException(string value)
	{
		// Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => Guard.ArgumentIsNotNullOrWhiteSpace(value));

		Assert.Equal(nameof(value), exception.ParamName);
    }

	[Fact]
    public void ArgumentIsNotNullOrWhiteSpace_NotNullOrWhiteSpaceValue_DoesNotThrow()
	{
		// Arrange
        var value = "abc";

		// Act
		Guard.ArgumentIsNotNullOrWhiteSpace(value);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void ArgumentIsNullOrWhiteSpace_NullOrWhiteSpaceValue_DoesNotThrow(string value)
	{
        // Act
        Guard.ArgumentIsNullOrWhiteSpace(value);
    }

    [Fact]
    public void ArgumentIsNullOrWhiteSpace_NotNullOrWhiteSpaceValue_ThrowsArgumentNullException()
	{
		// Arrange
        var value = "abc";

		// Act & Assert
		var exception = Assert.Throws<ArgumentNullException>(() => Guard.ArgumentIsNullOrWhiteSpace(value));
    }

	[Fact]
	public void ArgumentIsEmpty_EmptyValue_DoesNotThrow()
	{
		// Arrange
		var value = string.Empty;

		// Act
		Guard.ArgumentIsEmpty(value);
	}

	[Theory]
	[InlineData(null)]
	[InlineData("abc")]
	[InlineData(" ")]
	public void ArgumentIsEmpty_NonEmptyValue_ThrowsArgumentException(string value)
	{
		// Act & Assert
		var exception = Assert.Throws<ArgumentException>(() => Guard.ArgumentIsEmpty(value));

		Assert.Equal(nameof(value), exception.ParamName);
	}

	[Fact]
	public void ArgumentIsNotEmpty_EmptyValue_ThrowsArgumentException()
	{
		// Arrange
		var value = string.Empty;

		// Act & Assert
		var exception = Assert.Throws<ArgumentException>(() => Guard.ArgumentIsNotEmpty(value));

		Assert.Equal(nameof(value), exception.ParamName);
	}

	[Theory]
	[InlineData("abc")]
	[InlineData(" ")]
	public void ArgumentIsNotEmpty_NonEmptyValue_DoesNotThrow(string value)
	{
		// Act
		Guard.ArgumentIsNotEmpty(value);
	}

	[Theory]
	[InlineData(null)]
	[InlineData("")]
	[InlineData("   ")]
	public void ArgumentIsWhiteSpace_WhiteSpaceValue_DoesNotThrow(string value)
	{
		// Act
		Guard.ArgumentIsWhiteSpace(value);
	}

	[Fact]
	public void ArgumentIsWhiteSpace_NotWhiteSpaceValue_ThrowsArgumentException()
	{
		// Arrange
		var value = "abc";

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => Guard.ArgumentIsWhiteSpace(value));

		Assert.Equal(nameof(value), exception.ParamName);
	}

	[Theory]
	[InlineData(null)]
	[InlineData("")]
	[InlineData("   ")]
	public void ArgumentIsNotWhiteSpace_WhiteSpaceValue_ThrowsArgumentException(string value)
	{
		// Act & Assert
		var exception = Assert.Throws<ArgumentException>(() => Guard.ArgumentIsNotWhiteSpace(value));

		Assert.Equal(nameof(value), exception.ParamName);
	}

	[Fact]
	public void ArgumentIsNotWhiteSpace_NotWhiteSpaceValue_DoesNotThrow()
	{
		// Arrange
		var value = "abc";

		// Act
		Guard.ArgumentIsNotWhiteSpace(value);
	}
}
