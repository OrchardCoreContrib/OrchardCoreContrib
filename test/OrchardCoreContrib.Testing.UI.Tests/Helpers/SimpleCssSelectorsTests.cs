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
    public void ShouldGenerateCssSelectorByName()
    {
        // Act
        var selector = By.Name("p");

        // Assert
        Assert.Equal("p", selector);
    }

    [Fact]
    public void ShouldGenerateCssSelectorByNames()
    {
        // Act
        var selector = By.Name("h1", "h2", "h3");

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
    public void ShouldGenerateCssSelectorByClass()
    {
        // Act
        var selector = By.Class("red");

        // Assert
        Assert.Equal(".red", selector);
    }

    [Fact]
    public void ShouldGenerateCssSelectorByElementAndClass()
    {
        // Act
        var selector = By.Class("p", "red");

        // Assert
        Assert.Equal("p.red", selector);
    }
}
