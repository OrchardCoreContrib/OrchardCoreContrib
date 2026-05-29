using OrchardCoreContrib.Infrastructure;
using System.Numerics;
using Xunit;

namespace OrchardCoreContrib.Tests.Infrastructure;

public class GuardTests
{
    public static IEnumerable<object[]> ArgumentIsLessThanTestData1 =>
        [
        [typeof(int), -2.5, -1.5, "value"],
        [typeof(int), -2, -1, "value"],
        [typeof(int), 1, 2, "value"],
        [typeof(string), 1.5, 2.5, "value"]
        ];

    public static IEnumerable<object[]> ArgumentIsLessThanTestData2 =>
        [
        [typeof(int), -1.5, -2.5, "value"],
        [typeof(int), -2, -1, "value"],
        [typeof(int), 0, 0, "value"],
        [typeof(int), 2, 1, "value"],
        [typeof(string), 2.5, 1.5, "value"]
        ];

    public static IEnumerable<object[]> ArgumentIsLessThanOrEqualTestData1 =>
        [
        [typeof(int), -1.5, -2.5, "value"],
        [typeof(int), -1, -2, "value"],
        [typeof(int), 0, 0, "value"],
        [typeof(int), 2, 1, "value"],
        [typeof(string), 2.5, 1.5, "value"]
    ];

    public static IEnumerable<object[]> ArgumentIsLessThanOrEqualTestData2 =>
        [
        [typeof(int), -2.5, -1.5, "value"],
        [typeof(int), -1, -2, "value"],
        [typeof(int), 1, 2, "value"],
        [typeof(string), 1.5, 2.5, "value"]
    ];

    public static IEnumerable<object[]> ArgumentIsEqualTestData =>
        [
        [typeof(int), -1.5, -1.5, "value"],
        [typeof(int), -1, -1, "value"],
        [typeof(int), 0, 0, "value"],
        [typeof(int), 1, 1, "value"],
        [typeof(string), 1.5, 1.5, "value"]
    ];

    public static IEnumerable<object[]> ArgumentIsNegativeOrZeroTestData =>
        [
        [typeof(int), -1, "value"],
        [typeof(string), 0, "value"]
    ];

    public static IEnumerable<object[]> ArgumentIsGreaterThanTestData1 =>
        [
        [typeof(int), -1.5, -2.5, "value"],
        [typeof(int), -1, -2, "value"],
        [typeof(int), 2, 1, "value"],
        [typeof(string), 2.5, 1.5, "value"]
    ];

    public static IEnumerable<object[]> ArgumentIsGreaterThanTestData2 =>
        [
        [typeof(int), -2.5, -1.5, "value"],
        [typeof(int), -2, -1, "value"],
        [typeof(int), 0, 0, "value"],
        [typeof(int), 1, 2, "value"],
        [typeof(string), 1.5, 2.5, "value"]
        ];

    public static IEnumerable<object[]> ArgumentIsGreaterThanOrEqualTestData1 =>
        [
        [typeof(int), -1.5, -2.5, "value"],
        [typeof(int), -1, -2, "value"],
        [typeof(int), 0, 0, "value"],
        [typeof(int), 2, 1, "value"],
        [typeof(string), 2.5, 1.5, "value"]
    ];

    public static IEnumerable<object[]> ArgumentIsGreaterThanOrEqualTestData2 =>
        [
        [typeof(int), -2.5, -1.5, "value"],
        [typeof(int), -2, -1, "value"],
        [typeof(int), 1, 2, "value"],
        [typeof(string), 1.5, 2.5, "value"]
    ];

    [Fact]
    public void ArgumentNotNull_NullableValue_ThrowsArgumentNullException()
    {
        // Arrange
        string name = null;

        // Act & Assert
        var exception = Assert.Throws<ArgumentNullException>(() => Guard.ArgumentNotNull(name, nameof(name)));
        Assert.Null(name);
        Assert.Equal(nameof(name), exception.ParamName);
        Assert.Equal($"Value cannot be null. (Parameter '{nameof(name)}')", exception.Message);
    }

    [Theory]
    [InlineData(null, "name")]
    [InlineData("", "name")]
    public void ArgumentNotNullOrEmpty_NullableOrEmptyString_ThrowsArgumentNullOrEmptyException(string value, string name)
    {
        // Arrange

        // Act & Assert
        var exception = Assert.Throws<ArgumentNullOrEmptyException>(() => Guard.ArgumentNotNullOrEmpty(value, name));
        Assert.Equal(name, exception.ParamName);
        Assert.Equal($"Value cannot be null or empty. (Parameter '{name}')", exception.Message);
    }

    [Theory]
    [InlineData(null, "names")]
    [InlineData(new string[] { }, "names")]
    public void ArgumentNotNullOrEmpty_NullableOrEmptyCollection_ThrowsArgumentNullOrEmptyException(IEnumerable<string> value, string name)
    {
        // Arrange

        // Act & Assert
        var exception = Assert.Throws<ArgumentNullOrEmptyException>(() => Guard.ArgumentNotNullOrEmpty(value, name));
        Assert.Equal($"Value cannot be null or empty. (Parameter '{name}')", exception.Message);
    }

    [Fact]
    public void ArgumentIsZero_ZeroValue_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        var name = "value";
        var value = 0;

        // Act & Assert
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Guard.ArgumentIsZero(value, name));

        Assert.Equal($"value ('{value}') must be a non-zero value. (Parameter '{name}')\r\nActual value was {value}.", exception.Message);
    }

    [Fact]
    public void ArgumentIsZero_NonZeroValue_NotThrowsArgumentOutOfRangeException()
    {
        // Arrange
        var name = "value";
        var value = 100;

        // Act
        Guard.ArgumentIsZero(value, name);
    }

    [Fact]
    public void ArgumentIsNegative_NegativeValue_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        var name = "value";
        var value = -1;

        // Act & Assert
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Guard.ArgumentIsNegative(value, name));

        Assert.Equal($"value ('{value}') must be a non-negative value. (Parameter '{name}')\r\nActual value was {value}.", exception.Message);
    }

    [Fact]
    public void ArgumentIsNegative_NonNegativeValue_NotThrowsArgumentOutOfRangeException()
    {
        // Arrange
        var name = "value";
        var value = 100;

        // Act
        Guard.ArgumentIsNegative(value, name);
    }

    [Theory]
    [MemberData(nameof(ArgumentIsNegativeOrZeroTestData))]
    public void ArgumentIsNegativeOrZero_NegativeOrZeroValue_ThrowsArgumentOutOfRangeException<TNumber>(TNumber value, string name) where TNumber : INumberBase<TNumber>
    {
        // Act & Assert
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Guard.ArgumentIsNegativeOrZero(value, name));

        Assert.Equal($"value ('{value}') must be a non-negative and non-zero value. (Parameter '{name}')\r\nActual value was {value}.", exception.Message);
    }

    [Fact]
    public void ArgumentIsNegativeOrZero_PositiveValue_NotThrowsArgumentOutOfRangeException()
    {
        // Arrange
        var name = "value";
        var value = 100;

        // Act
        Guard.ArgumentIsNegativeOrZero(value, name);
    }

    [Theory]
    [MemberData(nameof(ArgumentIsLessThanTestData1))]
    public void ArgumentIsLessThan_FirstValueGreaterThanOrEqualAnotherOne_ThrowsArgumentOutOfRangeException<TNumber>(TNumber value, TNumber anotherValue, string name) where TNumber : IComparable<TNumber>
    {
        // Act & Assert
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Guard.ArgumentIsLessThan(value, anotherValue, name));

        Assert.Equal($"value ('{value}') must be greater than or equal to '{anotherValue}'. (Parameter '{name}')\r\nActual value was {value}.", exception.Message);
    }

    [Theory]
    [MemberData(nameof(ArgumentIsLessThanTestData2))]
    public void ArgumentIsLessThan_FirstValueLessThanAnotherOne_ThrowsArgumentOutOfRangeException<TNumber>(TNumber value, TNumber anotherValue, string name) where TNumber : IComparable<TNumber>
    {
        // Act
        Guard.ArgumentIsLessThan(value, anotherValue, name);
    }

    [Theory]
    [MemberData(nameof(ArgumentIsLessThanOrEqualTestData1))]
    public void ArgumentIsLessThanOrEqual_FirstValueGreaterThanAnotherOne_ThrowsArgumentOutOfRangeException<TNumber>(TNumber value, TNumber anotherValue, string name) where TNumber : IComparable<TNumber>
    {
        // Act & Assert
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Guard.ArgumentIsLessThanOrEqual(value, anotherValue, name));

        Assert.Equal($"value ('{value}') must be greater than '{anotherValue}'. (Parameter '{name}')\r\nActual value was {value}.", exception.Message);
    }

    [Theory]
    [MemberData(nameof(ArgumentIsLessThanOrEqualTestData2))]
    public void ArgumentIsLessThanOrEqual_FirstValueLessThanOrEqualAnotherOne_ThrowsArgumentOutOfRangeException<TNumber>(TNumber value, TNumber anotherValue, string name) where TNumber : IComparable<TNumber>
    {
        // Act
        Guard.ArgumentIsLessThanOrEqual(value, anotherValue, name);
    }

    [Theory]
    [MemberData(nameof(ArgumentIsEqualTestData))]
    public void ArgumentIsEqual_SameValues_ThrowsArgumentOutOfRangeException<TNumber>(TNumber value, TNumber anotherValue, string name) where TNumber : IEquatable<TNumber>
    {
        // Act & Assert
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Guard.ArgumentIsEqual(value, anotherValue, name));

        Assert.Equal($"value ('{value}') must not be equal to '{anotherValue}'. (Parameter '{name}')\r\nActual value was {value}.", exception.Message);
    }

    [Fact]
    public void ArgumentIsEqual_NotSameValues_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        var name = "value";
        var value = 100;
        var anotherValue = 200;

        // Act
        Guard.ArgumentIsEqual(value, anotherValue, name);
    }

    [Theory]
    [MemberData(nameof(ArgumentIsGreaterThanTestData1))]
    public void ArgumentIsGreaterThan_FirstValueLessThanOrEqualAnotherOne_ThrowsArgumentOutOfRangeException<TNumber>(TNumber value, TNumber anotherValue, string name) where TNumber : IComparable<TNumber>
    {
        // Act & Assert
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Guard.ArgumentIsGreaterThan(value, anotherValue, name));

        Assert.Equal($"value ('{value}') must be less than or equal to '{anotherValue}'. (Parameter '{name}')\r\nActual value was {value}.", exception.Message);
    }

    [Theory]
    [MemberData(nameof(ArgumentIsGreaterThanTestData2))]
    public void ArgumentIsGreaterThan_FirstValueGreaterThanAnotherOne_ThrowsArgumentOutOfRangeException<TNumber>(TNumber value, TNumber anotherValue, string name) where TNumber : IComparable<TNumber>
    {
        // Act
        Guard.ArgumentIsGreaterThan(value, anotherValue, name);
    }

    [Theory]
    [MemberData(nameof(ArgumentIsGreaterThanOrEqualTestData1))]
    public void ArgumentIsGreaterThanOrEqual_FirstValueLessThanAnotherOne_ThrowsArgumentOutOfRangeException<TNumber>(TNumber value, TNumber anotherValue, string name) where TNumber : IComparable<TNumber>
    {
        // Act & Assert
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Guard.ArgumentIsGreaterThanOrEqual(value, anotherValue, name));

        Assert.Equal($"value ('{value}') must be less than '{anotherValue}'. (Parameter '{name}')\r\nActual value was {value}.", exception.Message);
    }

    [Theory]
    [MemberData(nameof(ArgumentIsGreaterThanOrEqualTestData2))]
    public void ArgumentIsGreaterThanOrEqual_FirstValueGreaterThanOrEqualAnotherOne_ThrowsArgumentOutOfRangeException<TNumber>(TNumber value, TNumber anotherValue, string name) where TNumber : IComparable<TNumber>
    {
        // Act
        Guard.ArgumentIsGreaterThanOrEqual(value, anotherValue, name);
    }
}
