using Microsoft.Playwright;
using Moq;

namespace OrchardCoreContrib.Testing.UI.Tests;

public class ElementTests
{
    [Fact]
    public void GetElementInformation()
    {
        // Arrange
        var locatorMock = new Mock<ILocator>();
        locatorMock.Setup(l => l.InnerHTMLAsync(null))
            .ReturnsAsync("<h1>Orchard Core Contrib</h1>");

        locatorMock.Setup(l => l.InnerTextAsync(null))
            .ReturnsAsync("Orchard Core Contrib");

        locatorMock.Setup(l => l.IsDisabledAsync(null))
            .ReturnsAsync(false);

        locatorMock.Setup(l => l.IsVisibleAsync(null))
            .ReturnsAsync(true);

        // Act
        var element = new Element(locatorMock.Object);

        // Assert
        Assert.Equal("<h1>Orchard Core Contrib</h1>", element.InnerHtml);
        Assert.Equal("Orchard Core Contrib", element.InnerText);
        Assert.False(element.Enabled);
        Assert.True(element.Visible);
    }

    [Fact]
    public async Task ClickElement()
    {
        // Arrange
        var locatorMock = new Mock<ILocator>();
        var element = new Element(locatorMock.Object);

        // Act
        await element.ClickAsync();

        // Assert
        locatorMock.Verify(l => l.ClickAsync(null), Times.Once);
    }

    [Fact]
    public async Task TypeTextIntoElement()
    {
        // Arrange
        var locatorMock = new Mock<ILocator>();
        locatorMock.Setup(l => l.FillAsync(It.IsAny<string>(), null))
            .Callback(() =>
            {
                locatorMock.Setup(l => l.InnerTextAsync(null))
                    .ReturnsAsync("Orchard Core Contrib");
            });
        var element = new Element(locatorMock.Object);

        // Act
        await element.TypeAsync("Orchard Core Contrib");

        // Assert
        Assert.Equal("Orchard Core Contrib", element.InnerText);
    }
}
