using Moq;

namespace OrchardCoreContrib.Testing.UI.Tests;

public class BrowserTests
{
    private readonly Mock<Microsoft.Playwright.IBrowser> _browserMock;

    public BrowserTests()
    {
        _browserMock = new Mock<Microsoft.Playwright.IBrowser>();
        _browserMock.Setup(b => b.NewPageAsync(null))
            .ReturnsAsync(Mock.Of<Microsoft.Playwright.IPage>());
    }

    [Fact]
    public void ShouldCreateBrowser()
    {
        // Arrange
        var version = "12.5.0";

        _browserMock.Setup(b => b.Version).Returns(version);

        // Act
        var browser = new Browser(_browserMock.Object);

        // Assert
        Assert.NotNull(browser);
        Assert.Equal(version, browser.Version);
    }

    [Fact]
    public async Task ShouldOpenPage()
    {
        // Arrange
        var browser = new Browser(_browserMock.Object);

        // Act
        var page = await browser.OpenPageAsync("https://www.orchardcore.net");

        // Assert
        Assert.NotNull(page);
    }
}