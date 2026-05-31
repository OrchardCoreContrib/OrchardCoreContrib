using Xunit;

namespace OrchardCoreContrib.Infrastructure.Tests;

public partial class GuardTests
{
    [Fact]
    public void ArgumentNotNull_Null_ThrowsArgumentNullException()
    {
        // Arrange
        object value = null;

        // Act & Assert
        var exception = Assert.Throws<ArgumentNullException>(() => Guard.ArgumentNotNull(value));

        Assert.Equal(nameof(value), exception.ParamName);
    }

    [Fact]
    public void ArgumentNotNull_NotNull_DoesNotThrow()
    {
        // Arrange
        object value = new object();

        // Act
        Guard.ArgumentNotNull(value);
    }

    [Fact]
    public void ArgumentIsOfType_Generic_ExactType_DoesNotThrow()
    {
        // Arrange
        object value = 123;

        // Act
        Guard.ArgumentIsOfType<int>(value);
    }

    [Fact]
    public void ArgumentIsOfType_Generic_DifferentType_ThrowsArgumentException()
    {
        // Arrange
        object value = "abc";

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => Guard.ArgumentIsOfType<int>(value));

        Assert.Equal(nameof(value), exception.ParamName);
    }

    [Fact]
    public void ArgumentIsNotOfType_Generic_SameType_ThrowsArgumentException()
    {
        // Arrange
        object value = 123;

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => Guard.ArgumentIsNotOfType<int>(value));

        Assert.Equal(nameof(value), exception.ParamName);
    }

    [Fact]
    public void ArgumentIsNotOfType_Generic_DifferentType_DoesNotThrow()
    {
        // Arrange
        object value = "abc";

        // Act
        Guard.ArgumentIsNotOfType<int>(value);
    }

    [Fact]
    public void ArgumentIsOfType_Runtime_DifferentType_ThrowsArgumentException()
    {
        // Arrange
        object value = "abc";

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => Guard.ArgumentIsOfType(value, typeof(int)));

        Assert.Equal(nameof(value), exception.ParamName);
    }

    [Fact]
    public void ArgumentIsAssignableToType_Generic_Assignable_DoesNotThrow()
    {
        // Arrange
        object value = new DerivedType();

        // Act
        Guard.ArgumentIsAssignableToType<BaseType>(value);
    }

    [Fact]
    public void ArgumentIsAssignableToType_Runtime_NotAssignable_ThrowsArgumentException()
    {
        // Arrange
        object value = 123;

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => Guard.ArgumentIsAssignableToType(value, typeof(string)));

        Assert.Equal(nameof(value), exception.ParamName);
    }

    [Fact]
    public void ArgumentIsNotAssignableToType_Generic_Assignable_ThrowsArgumentException()
    {
        // Arrange
        object value = new DerivedType();

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => Guard.ArgumentIsNotAssignableToType<BaseType>(value));

        Assert.Equal(nameof(value), exception.ParamName);
    }

    [Fact]
    public void ArgumentIsNotAssignableToType_Runtime_Assignable_ThrowsArgumentException()
    {
        // Arrange
        object value = new DerivedType();

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => Guard.ArgumentIsNotAssignableToType(value, typeof(BaseType)));

        Assert.Equal(nameof(value), exception.ParamName);
    }

    private class BaseType;

    private class DerivedType : BaseType;
}
