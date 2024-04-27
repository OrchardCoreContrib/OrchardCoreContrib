using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace OrchardCoreContrib.Testing.UI.Infrastructure;

public class WebApplicationFactoryFixture<TStartup> : WebApplicationFactoryFixture where TStartup : class
{
    protected override IHost CreateWebHost() => new HostBuilder().ConfigureWebHostDefaults(webBuilder =>
    {
        webBuilder.UseStartup<TStartup>();
        webBuilder.UseUrls("http://127.0.0.1:0");
    }).Build();
}
