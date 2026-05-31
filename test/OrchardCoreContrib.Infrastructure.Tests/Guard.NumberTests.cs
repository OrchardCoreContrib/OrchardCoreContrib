using Xunit;

namespace OrchardCoreContrib.Infrastructure.Tests;

public partial class GuardTests
{
    [Fact]
    public void ArgumentIsZero_ZeroValue_DoesNotThrow()
    {
        var value = 0;

        Guard.ArgumentIsZero(value);
    }

    [Fact]
    public void ArgumentIsZero_NonZeroValue_ThrowsArgumentOutOfRangeException()
    {
        var value = 1;

        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Guard.ArgumentIsZero(value));
        Assert.Equal(nameof(value), exception.ParamName);
    }

    [Fact]
    public void ArgumentIsNegative_NegativeValue_ThrowsArgumentOutOfRangeException()
    {
        var value = -1;

        Guard.ArgumentIsNegative(value);
    }

    [Fact]
    public void ArgumentIsNegative_NonNegativeValue_DoesNotThrow()
    {
        var value = 0;

        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Guard.ArgumentIsNegative(value));
        Assert.Equal(nameof(value), exception.ParamName);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    public void ArgumentIsNegativeOrZero_NegativeValue_DoesNotThrow(int value)
    {
        Guard.ArgumentIsNegativeOrZero(value);
    }

    [Fact]
    public void ArgumentIsNegativeOrZero_NegativeOrZeroValue_ThrowsArgumentOutOfRangeException()
    {
        var value = 1;
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Guard.ArgumentIsNegativeOrZero(value));

        Assert.Equal(nameof(value), exception.ParamName);
    }

    [Fact]
    public void ArgumentIsEqual_EqualValues_DoesNotThrow()
    {
        var value = 10;
        var otherValue = 10;

        Guard.ArgumentIsEqual(value, otherValue);
    }

    [Fact]
    public void ArgumentIsEqual_DifferentValues_ThrowsArgumentOutOfRangeException()
    {
        var value = 10;
        var otherValue = 11;

        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Guard.ArgumentIsEqual(value, otherValue));
        Assert.Equal(nameof(value), exception.ParamName);
    }

    [Fact]
    public void ArgumentLessThan_LessThanOtherValue_DoesNotThrow()
    {
        var value = 9;
        var otherValue = 10;

        Guard.ArgumentLessThan(value, otherValue);
    }

    [Fact]
    public void ArgumentLessThan_GreaterThanOrEqualToOtherValue_ThrowsArgumentOutOfRangeException()
    {
        var value = 10;
        var otherValue = 10;

        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Guard.ArgumentLessThan(value, otherValue));
        Assert.Equal(nameof(value), exception.ParamName);
    }

    [Fact]
    public void ArgumentIsLessThanOrEqual_LessThanOrEqualToOtherValue_DoesNotThrow()
    {
        var value = 10;
        var otherValue = 10;

        Guard.ArgumentIsLessThanOrEqual(value, otherValue);
    }

    [Fact]
    public void ArgumentIsLessThanOrEqual_GreaterThanOtherValue_ThrowsArgumentOutOfRangeException()
    {
        var value = 11;
        var otherValue = 10;

        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Guard.ArgumentIsLessThanOrEqual(value, otherValue));
        Assert.Equal(nameof(value), exception.ParamName);
    }

    [Fact]
    public void ArgumentIsGreaterThan_GreaterThanOtherValue_DoesNotThrow()
    {
        var value = 11;
        var otherValue = 10;

        Guard.ArgumentIsGreaterThan(value, otherValue);
    }

    [Fact]
    public void ArgumentIsGreaterThan_LessThanOrEqualToOtherValue_ThrowsArgumentOutOfRangeException()
    {
        var value = 10;
        var otherValue = 10;

        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Guard.ArgumentIsGreaterThan(value, otherValue));
        Assert.Equal(nameof(value), exception.ParamName);
    }

    [Fact]
    public void ArgumentIsGreaterThanOrEqual_GreaterThanOrEqualToOtherValue_DoesNotThrow()
    {
        var value = 10;
        var otherValue = 10;

        Guard.ArgumentIsGreaterThanOrEqual(value, otherValue);
    }

    [Fact]
    public void ArgumentIsGreaterThanOrEqual_LessThanOtherValue_ThrowsArgumentOutOfRangeException()
    {
        var value = 9;
        var otherValue = 10;

        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Guard.ArgumentIsGreaterThanOrEqual(value, otherValue));
        Assert.Equal(nameof(value), exception.ParamName);
    }
}
