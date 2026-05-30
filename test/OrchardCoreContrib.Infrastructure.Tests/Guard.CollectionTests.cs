using Xunit;

namespace OrchardCoreContrib.Infrastructure.Tests;

public class GuardCollectionTests
{
	[Fact]
	public void ArgumentIsNull_WhenCollectionIsNotNull_ThrowsArgumentNullException()
	{
		// Arrange
		var value = new[] { 1 };

		// Act
		var exception = Assert.Throws<ArgumentNullException>(() => Guard.ArgumentIsNull(value));

		// Assert
		Assert.Equal(nameof(value), exception.ParamName);
	}

	[Fact]
	public void ArgumentIsNull_WhenCollectionIsNull_DoesNotThrow()
	{
		// Arrange
		int[] value = null;

		// Act
		Guard.ArgumentIsNull(value);
	}

	[Fact]
	public void ArgumentNotNull_WhenCollectionIsNull_ThrowsArgumentNullException()
	{
		// Arrange
		int[] value = null;

		// Act
		var exception = Assert.Throws<ArgumentNullException>(() => Guard.ArgumentNotNull(value));

		// Assert
		Assert.Equal(nameof(value), exception.ParamName);
	}

	[Fact]
	public void ArgumentNotNull_WhenCollectionIsNotNull_DoesNotThrow()
	{
		// Arrange
		var value = new[] { 1 };

		// Act
		Guard.ArgumentNotNull(value);
	}

	[Fact]
	public void ArgumentIsEmpty_WhenCollectionIsNotNull_ThrowsArgumentException()
	{
		// Arrange
		var value = Array.Empty<int>();

		// Act
		var exception = Assert.Throws<ArgumentException>(() => Guard.ArgumentIsEmpty(value));

		// Assert
		Assert.Equal(nameof(value), exception.ParamName);
		Assert.Equal($"Collection must be empty. (Parameter '{nameof(value)}')", exception.Message);
	}

	[Fact]
	public void ArgumentIsEmpty_WhenCollectionIsNull_DoesNotThrow()
	{
		// Arrange
		int[] value = null;

		// Act
		Guard.ArgumentIsEmpty(value);
	}

	[Fact]
	public void ArgumentIsNotEmpty_WhenCollectionIsEmpty_ThrowsArgumentException()
	{
		// Arrange
		var value = Array.Empty<int>();

		// Act
		var exception = Assert.Throws<ArgumentException>(() => Guard.ArgumentIsNotEmpty(value));

		// Assert
		Assert.Equal(nameof(value), exception.ParamName);
		Assert.Equal($"Collection must not be empty. (Parameter '{nameof(value)}')", exception.Message);
	}

	[Fact]
	public void ArgumentIsNotEmpty_WhenCollectionHasItems_DoesNotThrow()
	{
		// Arrange
		var value = new[] { 1 };

		// Act
		Guard.ArgumentIsNotEmpty(value);
	}

	[Fact]
	public void ArgumentNotNullOrEmpty_WhenCollectionIsNull_ThrowsArgumentNullException()
	{
		// Arrange
		int[] value = null;

		// Act
		var exception = Assert.Throws<ArgumentNullException>(() => Guard.ArgumentNotNullOrEmpty(value));

		// Assert
		Assert.Equal(nameof(value), exception.ParamName);
	}

	[Fact]
	public void ArgumentNotNullOrEmpty_WhenCollectionIsEmpty_ThrowsArgumentException()
	{
		// Arrange
		var value = Array.Empty<int>();

		// Act
		var exception = Assert.Throws<ArgumentException>(() => Guard.ArgumentNotNullOrEmpty(value));

		// Assert
		Assert.Equal(nameof(value), exception.ParamName);
		Assert.Equal($"Collection cannot be empty. (Parameter '{nameof(value)}')", exception.Message);
	}

	[Fact]
	public void ArgumentNotNullOrEmpty_WhenCollectionHasItems_DoesNotThrow()
	{
		// Arrange
		var value = new[] { 1 };

		// Act
		Guard.ArgumentNotNullOrEmpty(value);
	}

	[Fact]
	public void ArgumentDoesNotContainNullElements_WhenCollectionHasNull_ThrowsArgumentException()
	{
		// Arrange
		string[] value = ["a", null, "b"];

		// Act
		var exception = Assert.Throws<ArgumentException>(() => Guard.ArgumentDoesNotContainNullElements(value));

		// Assert
		Assert.Equal(nameof(value), exception.ParamName);
		Assert.Equal($"Collection contains null elements. (Parameter '{nameof(value)}')", exception.Message);
	}

	[Fact]
	public void ArgumentDoesNotContainNullElements_WhenCollectionHasNoNull_DoesNotThrow()
	{
		// Arrange
		string[] value = ["a", "b"];

		// Act
		Guard.ArgumentDoesNotContainNullElements(value);
	}

	[Fact]
	public void ArgumentContainsDuplicateElements_WhenCollectionHasDuplicates_ThrowsArgumentException()
	{
		// Arrange
		int[] value = [1, 1, 2];

		// Act
		var exception = Assert.Throws<ArgumentException>(() => Guard.ArgumentContainsDuplicateElements(value));

		// Assert
		Assert.Equal(nameof(value), exception.ParamName);
		Assert.Equal($"Collection contains duplicate elements. (Parameter '{nameof(value)}')", exception.Message);
	}

	[Fact]
	public void ArgumentContainsDuplicateElements_WhenCollectionHasUniqueItems_DoesNotThrow()
	{
		// Arrange
		int[] value = [1, 2, 3];

		// Act
		Guard.ArgumentContainsDuplicateElements(value);
	}
}
