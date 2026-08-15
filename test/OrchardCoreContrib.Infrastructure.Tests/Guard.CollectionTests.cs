using Xunit;

namespace OrchardCoreContrib.Infrastructure.Tests;

public class GuardCollectionTests
{
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
    public void ArgumentNotEmpty_WhenCollectionIsEmpty_ThrowsArgumentException()
    {
        // Arrange
        var value = Array.Empty<int>();

        // Act
        var exception = Assert.Throws<ArgumentException>(() => Guard.ArgumentNotEmpty(value));

        // Assert
        Assert.Equal(nameof(value), exception.ParamName);
        Assert.Equal($"Collection must not be empty. (Parameter '{nameof(value)}')", exception.Message);
    }

    [Fact]
    public void ArgumentNotEmpty_WhenCollectionHasItems_DoesNotThrow()
    {
        // Arrange
        var value = new[] { 1 };

        // Act
        Guard.ArgumentNotEmpty(value);
    }

    [Fact]
    public void ArgumentNotEmpty_WhenCollectionIsNull_ThrowsArgumentNullException()
    {
        // Arrange
        int[] value = null;

        // Act
        var exception = Assert.Throws<ArgumentNullException>(() => Guard.ArgumentNotEmpty(value));

        // Assert
        Assert.Equal(nameof(value), exception.ParamName);
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
        var exception = Assert.Throws<ArgumentException>(() => Guard.ArgumentDoesNotContainDuplicateElements(value));

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
        Guard.ArgumentDoesNotContainDuplicateElements(value);
    }
}
