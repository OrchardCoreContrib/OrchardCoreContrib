namespace OrchardCoreContrib.Testing.UI.Helpers.Tests;

public class CombinatorsCssSelectorsTests
{
    [InlineData("div", "p", false, "div p")]
    [InlineData("div", "p", true, "div > p")]
    [Theory]
    public void ShouldGenerateCssSelectorByDescendant(string descendantElement, string childElement, bool direct, string expectedSelector)
    {
        // Act
        var selector = By.Descendant(descendantElement, childElement, direct);

        // Assert
        Assert.Equal(expectedSelector, selector);
    }

    [InlineData("div", "p", true, "div + p")]
    [InlineData("div", "p", false, "div ~ p")]
    [Theory]
    public void ShouldGenerateCssSelectorBySibling(string siblingElementName, string elementName, bool isAdjacent, string expectedSelector)
    {
        // Act
        var selector = By.Sibling(siblingElementName, elementName, isAdjacent);

        // Assert
        Assert.Equal(expectedSelector, selector);
    }
}
