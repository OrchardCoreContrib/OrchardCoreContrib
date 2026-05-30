using Xunit;

namespace OrchardCoreContrib.Infrastructure.Tests;

public partial class GuardTests
{
    [Fact]
    public void ArgumentNotNull_Null_ThrowsArgumentNullException()
    {
        object value = null;

        var exception = Assert.Throws<ArgumentNullException>(() => Guard.ArgumentNotNull(value));

        Assert.Equal(nameof(value), exception.ParamName);
    }

    [Fact]
    public void ArgumentNotNull_NotNull_DoesNotThrow()
    {
        object value = new object();

        Guard.ArgumentNotNull(value);
    }

    [Fact]
    public void ArgumentIsOfType_Generic_ExactType_DoesNotThrow()
    {
        object value = 123;

        Guard.ArgumentIsOfType<int>(value);
    }

    [Fact]
    public void ArgumentIsOfType_Generic_DifferentType_ThrowsArgumentException()
    {
        object value = "abc";

        var exception = Assert.Throws<ArgumentException>(() => Guard.ArgumentIsOfType<int>(value));

        Assert.Equal(nameof(value), exception.ParamName);
    }

    [Fact]
    public void ArgumentIsNotOfType_Generic_SameType_ThrowsArgumentException()
    {
        object value = 123;

        var exception = Assert.Throws<ArgumentException>(() => Guard.ArgumentIsNotOfType<int>(value));

        Assert.Equal(nameof(value), exception.ParamName);
    }

    [Fact]
    public void ArgumentIsNotOfType_Generic_DifferentType_DoesNotThrow()
    {
        object value = "abc";

        Guard.ArgumentIsNotOfType<int>(value);
    }

    [Fact]
    public void ArgumentIsOfType_Runtime_DifferentType_ThrowsArgumentException()
    {
        object value = "abc";

        var exception = Assert.Throws<ArgumentException>(() => Guard.ArgumentIsOfType(value, typeof(int)));

        Assert.Equal(nameof(value), exception.ParamName);
    }

    [Fact]
    public void ArgumentIsAssignableToType_Generic_Assignable_DoesNotThrow()
    {
        object value = new DerivedType();

        Guard.ArgumentIsAssignableToType<BaseType>(value);
    }

    [Fact]
    public void ArgumentIsAssignableToType_Runtime_NotAssignable_ThrowsArgumentException()
    {
        object value = 123;

        var exception = Assert.Throws<ArgumentException>(() => Guard.ArgumentIsAssignableToType(value, typeof(string)));

        Assert.Equal(nameof(value), exception.ParamName);
    }

    [Fact]
    public void ArgumentIsNotAssignableToType_Generic_Assignable_ThrowsArgumentException()
    {
        object value = new DerivedType();

        var exception = Assert.Throws<ArgumentException>(() => Guard.ArgumentIsNotAssignableToType<BaseType>(value));

        Assert.Equal(nameof(value), exception.ParamName);
    }

    [Fact]
    public void ArgumentIsNotAssignableToType_Runtime_Assignable_ThrowsArgumentException()
    {
        object value = new DerivedType();

        var exception = Assert.Throws<ArgumentException>(() => Guard.ArgumentIsNotAssignableToType(value, typeof(BaseType)));

        Assert.Equal(nameof(value), exception.ParamName);
    }

    private class BaseType;

    private class DerivedType : BaseType;
}
