using Microsoft.Playwright;
using OrchardCoreContrib.Testing.UI.Helpers;

namespace OrchardCoreContrib.Testing.UI.Tests.Helpers;

public class CssSelectorsTests
{
    private static readonly string _binFolderPath = Path.GetDirectoryName(typeof(CssSelectorsTests).Assembly.Location);
    private static readonly string _pagesFolderPath = Path.Combine(_binFolderPath, "Pages");

    public static readonly IEnumerable<object[]> CombinatorsData =
    [
        new [] { By.Id("container") },
        new [] { By.TagName("body") },
        new [] { By.ClassName("red") },
        new [] { By.ClassName("red", "p") },
        new [] { By.Attribute("class") },
        new [] { By.Attribute("class", elementName: "p") },
        new [] { By.Attribute("class", "red") },
        new [] { By.Attribute("class", "red", "p") },
        new [] { By.AttributeContains("id", "con") },
        new [] { By.AttributeContains("id", "con", "div") },
        new [] { By.AttributeStartsWith("class", "re") },
        new [] { By.AttributeStartsWith("class", "re", "p") },
        new [] { By.AttributeEndsWith("class", "ed") },
        new [] { By.AttributeEndsWith("class", "ed", "p") },
        new [] { By.Descendant("div", "p") },
        new [] { By.Descendant("div", "a", direct: true) },
        new [] { By.Sibling("div", "h3") },
        new [] { By.Sibling("div", "p", adjacent: true) },
        //new [] { By.PseudoElement("marker") },
        //new [] { By.PseudoElement("first-line", "p.red") },
        new [] { By.PseudoClass("disabled") },
        new [] { By.PseudoClass("disabled", "input") },
    ];

    [MemberData(nameof(CombinatorsData))]
    [Theory]
    public async Task ShouldFindByCssSelector(string selector)
    {
        // Arrange
        var playwrightPage = await CreatePlaywrightPageAsync();

        await playwrightPage.GotoAsync(Path.Combine(_pagesFolderPath, "selectors.html"));

        var page = new Page(new PlaywrightPageAccessor(playwrightPage));

        // Act
        var element = page.FindElement(selector);

        // Assert
        Assert.True(element.Visible);
    }

    private static async Task<Microsoft.Playwright.IPage> CreatePlaywrightPageAsync()
    {
        var playwright = await Playwright.CreateAsync();
        var browser = await playwright.Chromium.LaunchAsync();

        return await browser.NewPageAsync();
    }
}
