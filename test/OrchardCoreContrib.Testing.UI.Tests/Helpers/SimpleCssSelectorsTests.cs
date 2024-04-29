namespace OrchardCoreContrib.Testing.UI.Helpers.Tests;

public class SimpleCssSelectorsTests
{
    [InlineData(new[] { "p" }, "p")]
    [InlineData(new[] { "h1", "h2", "h3" }, "h1, h2, h3")]
    [Theory]
    public void ShouldGenerateCssSelectorByTagNames(string[] tageNames, string expectedSelector)
    {
        // Act
        var selector = By.TagNames(tageNames);

        // Assert
        Assert.Equal(expectedSelector, selector);
    }

    [Fact]
    public void ShouldGenerateCssSelectorById()
    {
        // Act
        var selector = By.Id("btnSend");

        // Assert
        Assert.Equal("#btnSend", selector);
    }

    [InlineData("red", null, ".red")]
    [InlineData("red", "p", "p.red")]
    [Theory]
    public void ShouldGenerateCssSelectorByClassName(string className, string tagName, string exprectedSelector)
    {
        // Act
        var selector = By.ClassName(className, tagName);

        // Assert
        Assert.Equal(exprectedSelector, selector);
    }
}
