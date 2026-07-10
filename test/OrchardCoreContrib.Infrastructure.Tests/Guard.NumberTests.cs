using Xunit;

namespace OrchardCoreContrib.Infrastructure.Tests;

public partial class GuardTests
{
    [Fact]
    public void ArgumentIsZero_ZeroValue_DoesNotThrow()
    {
        // Arrange
        var value = 0;

        // Act
        Guard.ArgumentIsZero(value);
    }

    [Fact]
    public void ArgumentIsZero_NonZeroValue_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        var value = 1;

        // Act & Assert
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Guard.ArgumentIsZero(value));

        Assert.Equal(nameof(value), exception.ParamName);
    }

    [Fact]
    public void ArgumentIsNegative_NegativeValue__DoesNotThrow()
    {
        // Arrange
        var value = -1;

        // Act
        Guard.ArgumentIsNegative(value);
    }

    [Fact]
    public void ArgumentIsNegative_NonNegativeValue_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        var value = 0;

        // Act & Assert
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Guard.ArgumentIsNegative(value));

        Assert.Equal(nameof(value), exception.ParamName);
    }

    [Fact]
    public void ArgumentIsPositive_NonPositiveValue_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        var value = -1;

        // Act & Assert
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Guard.ArgumentIsPositive(value));

        Assert.Equal(nameof(value), exception.ParamName);
    }

    [Fact]
    public void ArgumentIsPositive_PositiveValue_DoesNotThrow()
    {
        // Arrange
        var value = 1;

        // Act
        Guard.ArgumentIsPositive(value);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    public void ArgumentIsNegativeOrZero_NegativeValue_DoesNotThrow(int value)
    {
        // Act
        Guard.ArgumentIsNegativeOrZero(value);
    }

    [Fact]
    public void ArgumentIsNegativeOrZero_NegativeOrZeroValue_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        var value = 1;

        // Act & Assert
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Guard.ArgumentIsNegativeOrZero(value));

        Assert.Equal(nameof(value), exception.ParamName);
    }

    [Fact]
    public void ArgumentIsEqual_EqualValues_DoesNotThrow()
    {
        // Arrange
        var value = 10;
        var otherValue = 10;

        // Act
        Guard.ArgumentIsEqual(value, otherValue);
    }

    [Fact]
    public void ArgumentIsEqual_DifferentValues_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        var value = 10;
        var otherValue = 11;

        // Act & Assert
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Guard.ArgumentIsEqual(value, otherValue));

        Assert.Equal(nameof(value), exception.ParamName);
    }

    [Fact]
    public void ArgumentLessThan_LessThanOtherValue_DoesNotThrow()
    {
        // Arrange
        var value = 9;
        var otherValue = 10;

        // Act
        Guard.ArgumentLessThan(value, otherValue);
    }

    [Fact]
    public void ArgumentLessThan_GreaterThanOrEqualToOtherValue_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        var value = 10;
        var otherValue = 10;

        // Act & Assert
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Guard.ArgumentLessThan(value, otherValue));

        Assert.Equal(nameof(value), exception.ParamName);
    }

    [Fact]
    public void ArgumentIsLessThanOrEqual_LessThanOrEqualToOtherValue_DoesNotThrow()
    {
        // Arrange
        var value = 10;
        var otherValue = 10;

        // Act
        Guard.ArgumentIsLessThanOrEqual(value, otherValue);
    }

    [Fact]
    public void ArgumentIsLessThanOrEqual_GreaterThanOtherValue_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        var value = 11;
        var otherValue = 10;

        // Act & Assert
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Guard.ArgumentIsLessThanOrEqual(value, otherValue));

        Assert.Equal(nameof(value), exception.ParamName);
    }

    [Fact]
    public void ArgumentIsGreaterThan_GreaterThanOtherValue_DoesNotThrow()
    {
        // Arrange
        var value = 11;
        var otherValue = 10;

        // Act
        Guard.ArgumentIsGreaterThan(value, otherValue);
    }

    [Fact]
    public void ArgumentIsGreaterThan_LessThanOrEqualToOtherValue_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        var value = 10;
        var otherValue = 10;

        // Act & Assert
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Guard.ArgumentIsGreaterThan(value, otherValue));

        Assert.Equal(nameof(value), exception.ParamName);
    }

    [Fact]
    public void ArgumentIsGreaterThanOrEqual_GreaterThanOrEqualToOtherValue_DoesNotThrow()
    {
        // Arrange
        var value = 10;
        var otherValue = 10;

        // Act
        Guard.ArgumentIsGreaterThanOrEqual(value, otherValue);
    }

    [Fact]
    public void ArgumentIsGreaterThanOrEqual_LessThanOtherValue_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        var value = 9;
        var otherValue = 10;

        // Act & Assert
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Guard.ArgumentIsGreaterThanOrEqual(value, otherValue));

        Assert.Equal(nameof(value), exception.ParamName);
    }
}
