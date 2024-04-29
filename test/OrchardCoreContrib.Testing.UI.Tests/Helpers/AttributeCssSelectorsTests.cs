namespace OrchardCoreContrib.Testing.UI.Helpers.Tests;

public class AttributeCssSelectorsTests
{
    [InlineData("target", null, null, "[target]")]
    [InlineData("target", null, "a", "a[target]")]
    [InlineData("target", "_blank", "a", "a[target=\"_blank\"]")]
    [InlineData("type", "submit", null, "[type=\"submit\"]")]
    [InlineData("name", "txtName", "input", "input[name=\"txtName\"]")]
    [Theory]
    public void ShouldGenerateCssSelectorByAttribute(string name, string value, string elementName, string expectedSelector)
    {
        // Act
        var selector = By.Attribute(name, value, elementName);

        // Assert
        Assert.Equal(expectedSelector, selector);
    }

    [InlineData("class", "test", true, "[class~=\"test\"]")]
    [InlineData("class", "t", false, "[class*=\"t\"]")]
    [Theory]
    public void ShouldGenerateCssSelectorByAttributeContainsValue(string name, string value, bool isWord, string expectedSelector)
    {
        // Act
        var selector = By.AttributeContains(name, value, isWord: isWord);

        // Assert
        Assert.Equal(expectedSelector, selector);
    }

    [Fact]
    public void ShouldGenerateCssSelectorByAttributeStartsWithValue()
    {
        // Act
        var selector = By.AttributeStartsWith("class", "test");

        // Assert
        Assert.Equal("[class^=\"test\"]", selector);
    }

    [Fact]
    public void ShouldGenerateCssSelectorByAttributeEndsWithValue()
    {
        // Act
        var selector = By.AttributeEndsWith("class", "test");

        // Assert
        Assert.Equal("[class$=\"test\"]", selector);
    }
}
