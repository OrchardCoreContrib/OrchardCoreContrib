using Microsoft.Extensions.Localization;
using Xunit;

namespace OrchardCoreContrib.Infrastructure.Tests;

public class ResultTests
{
    [Fact]
    public void Success_ReturnsSingletonSucceededResult()
    {
        // Arrange & Act
        var result1 = Result.Success();
        var result2 = Result.Success();

        // Assert
        Assert.True(result1.Succeeded);
        Assert.Empty(result1.Errors);
        Assert.Same(result1, result2);
    }

    [Fact]
    public void SuccessOfT_ReturnsSucceededResultWithValue()
    {
        // Arrange
        var value = 42;

        // Act
        var result = Result.Success(value);

        // Assert
        Assert.True(result.Succeeded);
        Assert.Equal(value, result.Value);
        Assert.Empty(result.Errors);
    }

    [Fact]
    public void Failed_WithNoErrors_ReturnsFailedResult()
    {
        // Arrange & Act
        var result = Result.Failed();

        // Assert
        Assert.False(result.Succeeded);
        Assert.Empty(result.Errors);
    }

    [Fact]
    public void Failed_WithResultErrors_ReturnsFailedResultWithErrors()
    {
        // Arrange
        var error1 = new ResultError { Key = "Name", Message = new LocalizedString("Name", "Name is required") };
        var error2 = new ResultError { Key = "Email", Message = new LocalizedString("Email", "Email is invalid") };

        // Act
        var result = Result.Failed(error1, error2);

        // Assert
        Assert.False(result.Succeeded);
        Assert.Collection(result.Errors,
            error => Assert.Same(error1, error),
            error => Assert.Same(error2, error));
    }

    [Fact]
    public void Failed_WithLocalizedString_ReturnsFailedResultWithSingleError()
    {
        // Arrange
        var message = new LocalizedString("Error", "Something went wrong");

        // Act
        var result = Result.Failed(message);

        // Assert
        Assert.False(result.Succeeded);

        var error = Assert.Single(result.Errors);
        Assert.Equal(string.Empty, error.Key);
        Assert.Equal(message, error.Message);
    }

    [Fact]
    public void FailedOfT_ReturnsFailedResultWithErrorsAndDefaultValue()
    {
        // Arrange
        var error = new ResultError { Key = "Code", Message = new LocalizedString("Code", "Invalid code") };

        // Act
        var result = Result.Failed<int>(error);

        // Assert
        Assert.False(result.Succeeded);
        Assert.Equal(default, result.Value);

        var actualError = Assert.Single(result.Errors);
        Assert.Same(error, actualError);
    }
}
