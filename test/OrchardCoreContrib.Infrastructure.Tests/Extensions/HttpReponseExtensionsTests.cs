using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Xunit;

namespace OrchardCoreContrib.Infrastructure.Extensions.Tests;

public class HttpReponseExtensionsTests
{
    [Fact]
    public void RedirectToAccessDeniedPage_SetsRedirectLocation()
    {
        // Arrange
        var services = new ServiceCollection();
        var cookieOptions = new CookieAuthenticationOptions
        {
            AccessDeniedPath = "/access-denied"
        };

        services.AddSingleton<IOptionsMonitor<CookieAuthenticationOptions>>(
            new TestOptionsMonitor<CookieAuthenticationOptions>(cookieOptions));

        var httpContext = new DefaultHttpContext
        {
            RequestServices = services.BuildServiceProvider()
        };

        var response = httpContext.Response;

        // Act
        response.RedirectToAccessDeniedPage();

        // Assert
        Assert.Equal(cookieOptions.AccessDeniedPath, response.Headers.Location.ToString());
        Assert.Equal(StatusCodes.Status403Forbidden, response.StatusCode);
    }

    private sealed class TestOptionsMonitor<TOptions>(TOptions options) : IOptionsMonitor<TOptions>
    {
        public TOptions CurrentValue => options;

        public TOptions Get(string name) => options;

        public IDisposable OnChange(Action<TOptions, string> listener) => null;
    }
}
