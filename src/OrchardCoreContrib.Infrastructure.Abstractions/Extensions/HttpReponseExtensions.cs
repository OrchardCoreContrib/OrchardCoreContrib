using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Microsoft.AspNetCore.Http;

/// <summary>
/// Provides extension methods for the <see cref="HttpResponse"/>.
/// </summary>
public static class HttpReponseExtensions
{
    /// <summary>
    /// Redirects the response to the access denied page defined in the cookie authentication options.
    /// </summary>
    /// <param name="httpResponse">The HTTP response.</param>
    public static void RedirectToAccessDeniedPage(this HttpResponse httpResponse)
    {
        var cookieAuthenticationOptions = httpResponse.HttpContext.RequestServices
            .GetService<IOptionsMonitor<CookieAuthenticationOptions>>()
            .Get(IdentityConstants.ApplicationScheme);

        httpResponse.Headers.Location = cookieAuthenticationOptions.AccessDeniedPath.ToString();
        httpResponse.StatusCode = StatusCodes.Status403Forbidden;
    }
}
