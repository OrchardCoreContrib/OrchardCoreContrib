using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace OrchardCoreContrib.Testing.UI.Tests;

public class UITestTests : UITest<UITestTests.SimpleStartup>
{
    [Fact]
    public async Task RunTest()
    {
        // Arrange
        var test = new UITest<SimpleStartup>();

        // Act
        await test.InitializeAsync();

        // Assert
        Assert.NotNull(test.Browser);
        Assert.NotNull(test.BaseUrl);
    }

    [Fact]
    public async Task NavigateToHomePage()
    {
        // Arrange & Act
        var page = await Browser.OpenPageAsync(BaseUrl + "foo");

        // Assert
        Assert.Contains("Hello, world!", page.Content);
    }

    public class SimpleStartup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.Map("/foo", app =>
            {
                app.Run(async context => await context.Response.WriteAsync("Hello, world!"));
            });
        }
    }
}
