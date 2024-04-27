using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Playwright;
using Xunit;
using PlaywrightBrowser = Microsoft.Playwright.IBrowser;

namespace OrchardCoreContrib.Testing.UI.Infrastructure;

public abstract class WebApplicationFactoryFixture : IAsyncLifetime
{
    private IHost _host;
    private IPlaywright _playwright;
    
    private readonly Lazy<Uri> _serverAddress;

    public WebApplicationFactoryFixture()
    {
        _serverAddress = new Lazy<Uri>(() =>
        {
            _host = CreateWebHost();
            _host.Start();

            var server = _host.Services.GetRequiredService<IServer>();

            return new Uri(server.Features.Get<IServerAddressesFeature>().Addresses.Single());
        });
    }

    public string ServerAddress => _serverAddress.Value.AbsoluteUri;

    public PlaywrightBrowser Browser { get; private set; }

    protected abstract IHost CreateWebHost();

    public async Task InitializeAsync()
    {
        _playwright = await Playwright.CreateAsync();

        Browser = await _playwright.Chromium.LaunchAsync();
    }

    public async Task DisposeAsync()
    {
        _playwright.Dispose();

        await _host.StopAsync();

        _host.Dispose();
    }
}
