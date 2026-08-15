using Xunit;

namespace OrchardCoreContrib.Infrastructure.Tests;

public partial class GuardTests
{
    [Fact]
    public void ArgumentNull_AllowsNull_DoesNotThrow()
    {
        // Act
        Guard.ArgumentNull(null);
    }

    [Fact]
    public void ArgumentNull_NonNull_ThrowsArgumentException()
    {
        // Act & Assert
        Assert.Throws<ArgumentException>(() => Guard.ArgumentNull(42));
    }

    [Fact]
    public void ArgumentNotNull_Null_ThrowsArgumentNullException()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => Guard.ArgumentNotNull(null));
    }

    [Fact]
    public void ArgumentNotNull_NotNull_DoesNotThrow()
    {
        // Act
        Guard.ArgumentNotNull("value");
    }

    [Fact]
    public void ArgumentOfType_CorrectType_DoesNotThrow()
    {
        // Act
        Guard.ArgumentOfType<string>("hello");
    }

    [Fact]
    public void ArgumentOfType_IncorrectType_ThrowsArgumentException()
    {
        // Act & Assert
        Assert.Throws<ArgumentException>(() => Guard.ArgumentOfType<string>(123));
    }

    [Fact]
    public void ArgumentOfType_Null_ThrowsArgumentNullException()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => Guard.ArgumentOfType<string>(null));
    }

    [Fact]
    public void ArgumentNotOfType_DifferentType_DoesNotThrow()
    {
        // Act
        Guard.ArgumentNotOfType<string>(123);
    }

    [Fact]
    public void ArgumentNotOfType_SameType_ThrowsArgumentException()
    {
        // Act & Assert
        Assert.Throws<ArgumentException>(() => Guard.ArgumentNotOfType<string>("x"));
    }

    [Fact]
    public void ArgumentEquals_Null_ThrowsArgumentNullException()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => Guard.ArgumentEquals(null, 1));
        Assert.Throws<ArgumentNullException>(() => Guard.ArgumentEquals(1, null));
    }

    [Fact]
    public void ArgumentNotEquals_NotEqual_DoesNotThrow()
    {
        // Act
        Guard.ArgumentNotEquals("Yes", "No");
    }

    [Fact]
    public void ArgumentNotEquals_Equal_ThrowsArgumentException()
    {
        // Act & Assert
        Assert.Throws<ArgumentException>(() => Guard.ArgumentNotEquals("Yes", "Yes"));
    }

    [Fact]
    public void ArgumentAssignableToType_Assignable_DoesNotThrow()
    {
        // Arrange
        var derived = new DerivedType();

        // Act
        Guard.ArgumentAssignableToType<BaseType>(derived);
    }

    [Fact]
    public void ArgumentAssignableToType_NotAssignable_ThrowsArgumentException()
    {
        // Arrange
        var other = new OtherType();

        // Act & Assert
        Assert.Throws<ArgumentException>(() => Guard.ArgumentAssignableToType<BaseType>(other));
    }

    [Fact]
    public void ArgumentAssignableToType_Null_ThrowsArgumentNullException()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => Guard.ArgumentAssignableToType<BaseType>(null));
    }

    [Fact]
    public void ArgumentNotAssignableToType_NotAssignable_DoesNotThrow()
    {
        // Arrange
        var other = new OtherType();

        // Act & Assert
        Guard.ArgumentNotAssignableToType<BaseType>(other);
    }

    [Fact]
    public void ArgumentNotAssignableToType_Assignable_ThrowsArgumentException()
    {
        // Arrange
        var derived = new DerivedType();

        // Act & Assert
        Assert.Throws<ArgumentException>(() => Guard.ArgumentNotAssignableToType<BaseType>(derived));
    }

    [Fact]
    public void ArgumentNotAssignableToType_Null_ThrowsArgumentNullException()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => Guard.ArgumentNotAssignableToType<BaseType>(null));
    }

    private class BaseType;

    private class DerivedType : BaseType;

    private class OtherType;
}
