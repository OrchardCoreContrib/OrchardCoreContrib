namespace OrchardCoreContrib.Testing.UI.Helpers.Tests;

public class PseudoClassCssSelectorsTests
{
    [Fact]
    public void ShouldGenerateCssSelectorByPseudoClassOnly()
    {
        // Arrange
        var pseudoClass = "root";

        // Act
        var result = By.PseudoClass(pseudoClass);

        // Assert
        Assert.Equal($":{pseudoClass}", result);
    }

    [InlineData("a", "active", "a:active")]
    [InlineData("p", "lang(it)", "p:lang(it)")]
    [InlineData("#news", "target", "#news:target")]
    [InlineData("a.highlight", "hover", "a.highlight:hover")]
    [InlineData("div", "hover", "div:hover")]
    [InlineData("p i", "first-child", "p i:first-child")]
    [Theory]
    public void ShouldGenerateCssSelectorByPseudoClass(string selector, string pseudoClass, string expectedSelector)
    {
        // Act
        var result = By.PseudoClass(selector, pseudoClass);

        // Assert
        Assert.Equal(expectedSelector, result);
    }
}
