namespace OrchardCoreContrib.Testing.UI.Helpers.Tests;

public class AttributeCssSelectorsTests
{
    [Fact]
    public void ShouldGenerateCssSelectorByAttribute()
    {
        // Act
        var selector = By.Attribute("target");

        // Assert
        Assert.Equal("[target]", selector);
    }

    [InlineData("name", "txtName", "[name='txtName']")]
    [InlineData("type", "password", "[type='password']")]
    [InlineData("type", "submit", "[type='submit']")]
    [Theory]
    public void ShouldGenerateCssSelectorByAttributeAndValue(string name, string value, string expectedSelector)
    {
        // Act
        var selector = By.Attribute(name, value);

        // Assert
        Assert.Equal(expectedSelector, selector);
    }

    [InlineData("class", "test", true, "[class~=\"test\"]")]
    [InlineData("class", "t", false, "[class*=\"t\"]")]
    [Theory]
    public void ShouldGenerateCssSelectorByAttributeContainsValue(string name, string value, bool isWord, string expectedSelector)
    {
        // Act
        var selector = By.AttributeContains(name, value, isWord);

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
