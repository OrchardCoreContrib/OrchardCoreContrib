namespace OrchardCoreContrib.Testing.UI.Helpers.Tests;

public class PseudoElementCssSelectorsTests
{
    [InlineData("marker", null, "::marker")]
    [InlineData("after", "p", "p::after")]
    [InlineData("first-letter", "p.intro", "p.intro::first-letter")]
    [InlineData("selection", "div p", "div p::selection")]
    [Theory]
    public void ShouldGenerateCssSelectorByPseudoElement(string pseudoElement, string selector, string expectedSelector)
    {
        // Act
        var result = By.PseudoElement(pseudoElement, selector);

        // Assert
        Assert.Equal(expectedSelector, result);
    }
}
