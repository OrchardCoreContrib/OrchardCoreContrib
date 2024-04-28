using Microsoft.Playwright;
using Moq;

namespace OrchardCoreContrib.Testing.UI.Tests;

public class PageTests
{
    private static readonly string _pagesFolderPath = Path.Combine(Path.GetDirectoryName(typeof(PageTests).Assembly.Location), "Pages");

    [Fact]
    public void ShouldCreatePage()
    {
        // Arrange
        var playwrightPageAccessor = new PlaywrightPageAccessor(Mock.Of<Microsoft.Playwright.IPage>());

        // Act
        var page = new Page(playwrightPageAccessor);

        // Assert
        Assert.NotNull(page);
        Assert.Same(playwrightPageAccessor.PlaywrightPage, page.InnerPage);
    }

    [Fact]
    public async Task GetPageInformation()
    {
        // Arrange
        var pageMock = new Mock<Microsoft.Playwright.IPage>();
        pageMock.Setup(p => p.GotoAsync(It.IsAny<string>(), null))
            .ReturnsAsync(Mock.Of<IResponse>());
        pageMock.Setup(p => p.TitleAsync())
            .ReturnsAsync("Orchard Core Contrib");
        pageMock.Setup(p => p.ContentAsync())
            .ReturnsAsync("<h1>Welcome to Orchard Core Contrib (OCC)</h1>");

        var playwrightPageAccessor = new PlaywrightPageAccessor(pageMock.Object);

        // Act
        var page = new Page(playwrightPageAccessor);
        await page.GoToAsync("www.occ.com");

        // Assert
        Assert.Equal("Orchard Core Contrib", page.Title);
        Assert.Equal("<h1>Welcome to Orchard Core Contrib (OCC)</h1>", page.Content);
    }

    [Fact]
    public void ShouldFindElement()
    {
        // Arrange
        var pageMock = new Mock<Microsoft.Playwright.IPage>();

        pageMock.Setup(p => p.Locator(It.IsAny<string>(), null))
            .Returns(Mock.Of<ILocator>());

        var playwrightPageAccessor = new PlaywrightPageAccessor(pageMock.Object);

        var page = new Page(playwrightPageAccessor);

        // Act
        var result = page.FindElement("selector");

        // Assert
        Assert.NotNull(result);
    }

    [Fact]
    public async Task ShouldClickAnElement()
    {
        // Arrange
        var playwrightPage = await CreatePlaywrightPageAsync();

        await playwrightPage.GotoAsync(Path.Combine(_pagesFolderPath, "index.html"));

        var page = new Page(new PlaywrightPageAccessor(playwrightPage));

        // Act
        await page.ClickAsync("button");

        // Assert
        var paragraph = page.FindElement("#para");
        Assert.Equal("The button is clicked!!", paragraph.InnerText);
    }

    private static async Task<Microsoft.Playwright.IPage> CreatePlaywrightPageAsync()
    {
        var playwright = await Playwright.CreateAsync();
        var browser = await playwright.Chromium.LaunchAsync();
        
        return await browser.NewPageAsync();
    }
}