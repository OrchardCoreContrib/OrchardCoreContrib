namespace OrchardCoreContrib.Testing.UI.Helpers.Tests;

public class CombinatorsCssSelectorsTests
{
    [Fact]
    public void ShouldGenerateCssSelectorByDescendant()
    {
        // Act
        var selector = By.Descendant("div", "p");

        // Assert
        Assert.Equal("div p", selector);
    }

    [Fact]
    public void ShouldGenerateCssSelectorByChild()
    {
        // Act
        var selector = By.Child("div", "p");

        // Assert
        Assert.Equal("div > p", selector);
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
