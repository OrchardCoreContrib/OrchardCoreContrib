using Xunit;

namespace OrchardCoreContrib.Infrastructure.Tests;

public class ResultErrorTests
{
    [Fact]
    public void ResultError_DefaultKey_IsEmptyString()
    {
        // Arrange & Act
        var error = new ResultError();

        // Assert
        Assert.Equal(string.Empty, error.Key);
    }
}
