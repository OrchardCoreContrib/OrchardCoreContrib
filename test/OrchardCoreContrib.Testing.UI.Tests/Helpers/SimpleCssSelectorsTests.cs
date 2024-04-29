namespace OrchardCoreContrib.Testing.UI.Helpers.Tests;

public class SimpleCssSelectorsTests
{
    [Fact]
    public void ShouldGenerateCssSelectorForAllElements()
    {
        // Act
        var selector = By.All();

        // Assert
        Assert.Equal("*", selector);
    }

    [Fact]
    public void ShouldGenerateCssSelectorByTagName()
    {
        // Act
        var selector = By.TagName("p");

        // Assert
        Assert.Equal("p", selector);
    }

    [Fact]
    public void ShouldGenerateCssSelectorByTagNames()
    {
        // Act
        var selector = By.TagName("h1", "h2", "h3");

        // Assert
        Assert.Equal("h1, h2, h3", selector);
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
    public void ShouldGenerateCssSelectorByClassName()
    {
        // Act
        var selector = By.ClassName("red");

        // Assert
        Assert.Equal(".red", selector);
    }

    [Fact]
    public void ShouldGenerateCssSelectorByElementAndClassName()
    {
        // Act
        var selector = By.ClassName("p", "red");

        // Assert
        Assert.Equal("p.red", selector);
    }
}
