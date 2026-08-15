using Xunit;

namespace OrchardCoreContrib.Infrastructure.Tests;

public class GuardEnumTests
{
    private const string ParamName = "valueParam";

    private enum SimpleEnum
    {
        None = 0,
        One = 1,
        Two = 2
    }

    [Flags]
    private enum FlagsEnumWithCombined
    {
        None = 0,
        A = 1,
        B = 2,
        AB = 3
    }

    [Flags]
    private enum FlagsEnumWithoutCombined
    {
        A = 1,
        B = 2
    }

    private enum DuplicateValueEnum
    {
        Foo = 0,
        Bar = 0,
        Baz = 1
    }

    private enum NoZeroEnum
    {
        One = 1,
        Two = 2
    }

    [Fact]
    public void ArgumentIsDefined_WithDefinedValue_DoesNotThrow()
    {
        // Arrange & Act
        var exception = Record.Exception(() => Guard.ArgumentIsDefined(SimpleEnum.One, ParamName));

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void ArgumentIsDefined_WithUndefinedValue_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        var undefined = (SimpleEnum)99;

        // Act
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Guard.ArgumentIsDefined(undefined, ParamName));

        // Assert
        Assert.Equal(ParamName, exception.ParamName);
        Assert.Contains(nameof(SimpleEnum), exception.Message);
    }

    [Fact]
    public void ArgumentIsDefined_FlagsCompositeNotDefined_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        var composite = (FlagsEnumWithoutCombined)((int)FlagsEnumWithoutCombined.A | (int)FlagsEnumWithoutCombined.B);

        // Act
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Guard.ArgumentIsDefined(composite, ParamName));

        // Assert
        Assert.Equal(ParamName, exception.ParamName);
    }

    [Fact]
    public void ArgumentIsDefined_FlagsCompositeDefined_DoesNotThrow()
    {
        // Arrange
        var composite = FlagsEnumWithCombined.A | FlagsEnumWithCombined.B;

        // Act
        var exception = Record.Exception(() => Guard.ArgumentIsDefined(composite, ParamName));

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void ArgumentIsDefined_DuplicateNumericValue_IsConsideredDefined()
    {
        // Arrange & Act
        var exception = Record.Exception(() => Guard.ArgumentIsDefined(DuplicateValueEnum.Bar, ParamName));

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void ArgumentNotDefault_DefaultValue_Throws_WhenZeroIsDefined()
    {
        // Arrange & Act
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Guard.ArgumentNotDefault(SimpleEnum.None, ParamName));

        // Assert
        Assert.Equal(ParamName, exception.ParamName);
        Assert.Contains("default", exception.Message, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public void ArgumentNotDefault_DefaultValue_Throws_WhenZeroIsNotDefined()
    {
        // Arrange
        var defaultValue = default(NoZeroEnum);

        // Act
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Guard.ArgumentNotDefault(defaultValue, ParamName));

        // Assert
        Assert.Equal(ParamName, exception.ParamName);
    }

    [Fact]
    public void ArgumentNotDefault_NonDefaultValue_DoesNotThrow()
    {
        // Arrange & Act
        var exception = Record.Exception(() => Guard.ArgumentNotDefault(SimpleEnum.Two, ParamName));

        // Assert
        Assert.Null(exception);
    }
}
