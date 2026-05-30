using Xunit;

namespace OrchardCoreContrib.Infrastructure.Tests;

public partial class GuardTests
{
	[Fact]
	public void ArgumentIsNullOrEmpty_NullValue_DoesNotThrow()
	{
		string value = null;

		Guard.ArgumentIsNullOrEmpty(value);
	}

	[Fact]
	public void ArgumentIsNullOrEmpty_EmptyValue_DoesNotThrow()
	{
		var value = string.Empty;

		Guard.ArgumentIsNullOrEmpty(value);
	}

	[Fact]
	public void ArgumentIsNullOrEmpty_NonEmptyValue_ThrowsArgumentNullOrEmptyException()
	{
		var value = "abc";

		var exception = Assert.Throws<ArgumentNullOrEmptyException>(() => Guard.ArgumentIsNullOrEmpty(value));
		Assert.Equal(nameof(value), exception.ParamName);
	}

	[Theory]
	[InlineData(null)]
	[InlineData("")]
	public void ArgumentNotNullOrEmpty_NullOrEmptyValue_ThrowsArgumentNullException(string value)
	{
		var exception = Assert.Throws<ArgumentNullException>(() => Guard.ArgumentNotNullOrEmpty(value));
		Assert.Equal(nameof(value), exception.ParamName);
	}

	[Fact]
	public void ArgumentNotNullOrEmpty_NonEmptyValue_DoesNotThrow()
	{
		var value = "abc";

		Guard.ArgumentNotNullOrEmpty(value);
	}

	[Theory]
	[InlineData(null)]
	[InlineData("")]
	[InlineData("   ")]
	public void ArgumentIsNullOrWhiteSpace_NullOrWhiteSpaceValue_DoesNotThrow(string value)
	{
		Guard.ArgumentIsNullOrWhiteSpace(value);
	}

	[Fact]
	public void ArgumentIsNullOrWhiteSpace_NotWhiteSpaceValue_ThrowsArgumentNullException()
	{
		var value = "abc";

		var exception = Assert.Throws<ArgumentNullException>(() => Guard.ArgumentIsNullOrWhiteSpace(value));
		Assert.Equal(nameof(value), exception.ParamName);
	}

	[Theory]
	[InlineData(null)]
	[InlineData("")]
	[InlineData("   ")]
	public void ArgumentIsNotNullOrWhiteSpace_NullOrWhiteSpaceValue_ThrowsArgumentNullException(string value)
	{
		var exception = Assert.Throws<ArgumentNullException>(() => Guard.ArgumentIsNotNullOrWhiteSpace(value));
		Assert.Equal(nameof(value), exception.ParamName);
	}

	[Fact]
	public void ArgumentIsNotNullOrWhiteSpace_NotWhiteSpaceValue_DoesNotThrow()
	{
		var value = "abc";

		Guard.ArgumentIsNotNullOrWhiteSpace(value);
	}

	[Fact]
	public void ArgumentIsEmpty_EmptyValue_DoesNotThrow()
	{
		var value = string.Empty;

		Guard.ArgumentIsEmpty(value);
	}

	[Theory]
	[InlineData(null)]
	[InlineData("abc")]
	[InlineData(" ")]
	public void ArgumentIsEmpty_NonEmptyValue_ThrowsArgumentException(string value)
	{
		var exception = Assert.Throws<ArgumentException>(() => Guard.ArgumentIsEmpty(value));
		Assert.Equal(nameof(value), exception.ParamName);
	}

	[Fact]
	public void ArgumentIsNotEmpty_EmptyValue_ThrowsArgumentException()
	{
		var value = string.Empty;

		var exception = Assert.Throws<ArgumentException>(() => Guard.ArgumentIsNotEmpty(value));
		Assert.Equal(nameof(value), exception.ParamName);
	}

	[Theory]
	[InlineData("abc")]
	[InlineData(" ")]
	public void ArgumentIsNotEmpty_NonEmptyValue_DoesNotThrow(string value)
	{
		Guard.ArgumentIsNotEmpty(value);
	}

	[Theory]
	[InlineData(null)]
	[InlineData("")]
	[InlineData("   ")]
	public void ArgumentIsWhiteSpace_WhiteSpaceValue_DoesNotThrow(string value)
	{
		Guard.ArgumentIsWhiteSpace(value);
	}

	[Fact]
	public void ArgumentIsWhiteSpace_NotWhiteSpaceValue_ThrowsArgumentException()
	{
		var value = "abc";

		var exception = Assert.Throws<ArgumentException>(() => Guard.ArgumentIsWhiteSpace(value));
		Assert.Equal(nameof(value), exception.ParamName);
	}

	[Theory]
	[InlineData(null)]
	[InlineData("")]
	[InlineData("   ")]
	public void ArgumentIsNotWhiteSpace_WhiteSpaceValue_ThrowsArgumentException(string value)
	{
		var exception = Assert.Throws<ArgumentException>(() => Guard.ArgumentIsNotWhiteSpace(value));
		Assert.Equal(nameof(value), exception.ParamName);
	}

	[Fact]
	public void ArgumentIsNotWhiteSpace_NotWhiteSpaceValue_DoesNotThrow()
	{
		var value = "abc";

		Guard.ArgumentIsNotWhiteSpace(value);
	}
}
