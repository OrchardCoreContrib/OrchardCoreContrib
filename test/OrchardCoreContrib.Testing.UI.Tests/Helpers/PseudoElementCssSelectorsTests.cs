namespace OrchardCoreContrib.Testing.UI.Helpers.Tests;

public class PseudoElementCssSelectorsTests
{
    [Fact]
    public void ShouldGenerateCssSelectorByPseudoElementOnly()
    {
        // Arrange
        var pseudoElement = "marker";

        // Act
        var result = By.PseudoElement(pseudoElement);

        // Assert
        Assert.Equal($"::{pseudoElement}", result);
    }

    [InlineData("p", "after", "p::after")]
    [InlineData("p.intro", "first-letter", "p.intro::first-letter")]
    [InlineData("div p", "selection", "div p::selection")]
    [Theory]
    public void ShouldGenerateCssSelectorByPseudoElement(string selector, string pseudoElement, string expectedSelector)
    {
        // Act
        var result = By.PseudoElement(selector, pseudoElement);

        // Assert
        Assert.Equal(expectedSelector, result);
    }
}
