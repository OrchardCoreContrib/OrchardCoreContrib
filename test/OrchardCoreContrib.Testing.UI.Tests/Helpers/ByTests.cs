namespace OrchardCoreContrib.Testing.UI.Helpers.Tests;

public class ByTests
{
    [Fact]
    public void ShouldGenerateCssSelectorByName()
    {
        // Act
        var selector = By.Name("p");

        // Assert
        Assert.Equal("p", selector);
    }

    [Fact]
    public void ShouldGenerateCssSelectorById()
    {
        // Act
        var selector = By.Id("btnSend");

        // Assert
        Assert.Equal("#btnSend", selector);
    }

    [Fact]
    public void ShouldGenerateCssSelectorByClass()
    {
        // Act
        var selector = By.Class("red");

        // Assert
        Assert.Equal(".red", selector);
    }

    [InlineData("target", null, "[target]")]
    [InlineData("name", "txtName", "[name='txtName']")]
    [InlineData("type", "password", "[type='password']")]
    [InlineData("type", "submit", "[type='submit']")]
    [Theory]
    public void ShouldGenerateCssSelectorByAttribute(string name, string value, string expectedSelector)
    {
        // Act
        var selector = By.Attribute(name, value);

        // Assert
        Assert.Equal(expectedSelector, selector);
    }
}
