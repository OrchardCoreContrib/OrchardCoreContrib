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

    [InlineData("root", null, ":root")]
    [InlineData("active", "a", "a:active")]
    [InlineData("lang(it)", "p", "p:lang(it)")]
    [InlineData("target", "#news", "#news:target")]
    [InlineData("hover", "a.highlight", "a.highlight:hover")]
    [InlineData("hover", "div", "div:hover")]
    [InlineData("first-child", "p i", "p i:first-child")]
    [Theory]
    public void ShouldGenerateCssSelectorByPseudoClass(string pseudoClass, string selector, string expectedSelector)
    {
        // Act
        var result = By.PseudoClass(pseudoClass, selector);

        // Assert
        Assert.Equal(expectedSelector, result);
    }
}
