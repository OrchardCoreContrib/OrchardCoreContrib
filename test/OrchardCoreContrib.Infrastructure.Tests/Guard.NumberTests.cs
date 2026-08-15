using Xunit;

namespace OrchardCoreContrib.Infrastructure.Tests;

public partial class GuardTests
{
    [Fact]
    public void ArgumentEquals_EqualValues_DoesNotThrow()
    {
        // Arrange
        var value = 10;
        var otherValue = 10;

        // Act
        Guard.ArgumentEquals(value, otherValue);
    }

    [Fact]
    public void ArgumentEquals_DifferentValues_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        var value = 10;
        var otherValue = 11;

        // Act & Assert
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Guard.ArgumentEquals(value, otherValue));

        Assert.Equal(nameof(value), exception.ParamName);
    }

    [Fact]
    public void ArgumentNotEquals_DifferentValues_DoesNotThrow()
    {
        // Arrange
        var value = 10;
        var otherValue = 11;

        // Act
        Guard.ArgumentNotEquals(value, otherValue);
    }

    [Fact]
    public void ArgumentNotEquals_EqualValues_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        var value = 10;
        var otherValue = 10;

        // Act & Assert
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Guard.ArgumentNotEquals(value, otherValue));

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
        Guard.ArgumentLessThanOrEqual(value, otherValue);
    }

    [Fact]
    public void ArgumentIsLessThanOrEqual_GreaterThanOtherValue_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        var value = 11;
        var otherValue = 10;

        // Act & Assert
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Guard.ArgumentLessThanOrEqual(value, otherValue));

        Assert.Equal(nameof(value), exception.ParamName);
    }

    [Fact]
    public void ArgumentIsGreaterThan_GreaterThanOtherValue_DoesNotThrow()
    {
        // Arrange
        var value = 11;
        var otherValue = 10;

        // Act
        Guard.ArgumentGreaterThan(value, otherValue);
    }

    [Fact]
    public void ArgumentIsGreaterThan_LessThanOrEqualToOtherValue_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        var value = 10;
        var otherValue = 10;

        // Act & Assert
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Guard.ArgumentGreaterThan(value, otherValue));

        Assert.Equal(nameof(value), exception.ParamName);
    }

    [Fact]
    public void ArgumentIsGreaterThanOrEqual_GreaterThanOrEqualToOtherValue_DoesNotThrow()
    {
        // Arrange
        var value = 10;
        var otherValue = 10;

        // Act
        Guard.ArgumentGreaterThanOrEqual(value, otherValue);
    }

    [Fact]
    public void ArgumentIsGreaterThanOrEqual_LessThanOtherValue_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        var value = 9;
        var otherValue = 10;

        // Act & Assert
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Guard.ArgumentGreaterThanOrEqual(value, otherValue));

        Assert.Equal(nameof(value), exception.ParamName);
    }

    [Fact]
    public void ArgumentInRange_DoesNotThrow_ForValueWithinRange_Int()
    {
        // Act
        Guard.ArgumentInRange(1, 5, 3);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(5)]
    public void ArgumentInRange_Allows_InclusiveBoundaries_Int(int value)
    {
        // Act
        Guard.ArgumentInRange(1, 5, value);
    }

    [Fact]
    public void ArgumentInRange_Throws_ForValueBelowMin_Int()
    {
        // Arrange
        var value = 10;

        // Act & Assert
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Guard.ArgumentInRange(1, 5, value));

        Assert.Equal(nameof(value), exception.ParamName);
        Assert.Contains("must be between 1 and 5 (inclusive)", exception.Message);
    }

    [Fact]
    public void ArgumentInRange_Throws_ForValueAboveMax_Int()
    {
        // Arrange
        var value = 10;

        // Act & Assert
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Guard.ArgumentInRange(1, 5, value));

        Assert.Equal(nameof(value), exception.ParamName);
        Assert.Contains("must be between 1 and 5 (inclusive)", exception.Message);
    }

    [Fact]
    public void ArgumentInRange_Throws_ForValueAboveMax_Double_WithSuppliedName()
    {
        // Act & Assert
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Guard.ArgumentInRange(0.0, 1.0, 2.5, "myParam"));

        Assert.Equal("myParam", exception.ParamName);
        Assert.Contains("myParam must be between 0 and 1 (inclusive)", exception.Message);
    }
}
