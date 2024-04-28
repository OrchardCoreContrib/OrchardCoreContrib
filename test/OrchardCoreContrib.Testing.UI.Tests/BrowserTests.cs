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

        var playwrightBrowserAccessor = new PlaywrightBrowserAccessor(_browserMock.Object);

        // Act
        var browser = new Browser(playwrightBrowserAccessor, BrowserType.Edge, headless: true);

        // Assert
        Assert.NotNull(browser);
        Assert.Equal(BrowserType.Edge, browser.Type);
        Assert.Equal(version, browser.Version);
        Assert.True(browser.Headless);
        Assert.Same(playwrightBrowserAccessor.PlaywrightBrowser, browser.InnerBrowser);
    }

    [Fact]
    public async Task ShouldOpenPage()
    {
        // Arrange
        var playwrightBrowserAccessor = new PlaywrightBrowserAccessor(_browserMock.Object);
        var browser = new Browser(playwrightBrowserAccessor, BrowserType.Edge, headless: true);

        // Act
        var page = await browser.OpenPageAsync("https://www.orchardcore.net");

        // Assert
        Assert.NotNull(page);
    }
}