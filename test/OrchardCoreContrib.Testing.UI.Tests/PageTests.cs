using Microsoft.Playwright;
using Moq;

namespace OrchardCoreContrib.Testing.UI.Tests;

public class PageTests
{
    [Fact]
    public void ShouldCreatePage()
    {
        // Arrange
        var pageMock = Mock.Of<Microsoft.Playwright.IPage>();

        // Act
        var page = new Page(pageMock);

        // Assert
        Assert.NotNull(page);
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

        // Act
        var page = new Page(pageMock.Object);
        await page.GoToAsync("www.occ.com");

        // Assert
        Assert.Equal("Orchard Core Contrib", page.Title);
        Assert.Equal("<h1>Welcome to Orchard Core Contrib (OCC)</h1>", page.Content);
    }
}