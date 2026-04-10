using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;

namespace OrchardCoreContrib.Testing;

public class OrchardCoreWebApplicationFactory<TEntryPoint> : WebApplicationFactory<TEntryPoint> where TEntryPoint : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        var shellsApplicationDataPath = Path.Combine(Directory.GetCurrentDirectory(), "App_Data");

        if (Directory.Exists(shellsApplicationDataPath))
        {
            Directory.Delete(shellsApplicationDataPath, true);
        }

        builder.UseContentRoot(Directory.GetCurrentDirectory());
    }

    protected override IWebHostBuilder CreateWebHostBuilder()
        => WebHostBuilderFactory.CreateFromAssemblyEntryPoint(typeof(TEntryPoint).Assembly, []);

    protected override IHostBuilder CreateHostBuilder()
        => Host.CreateDefaultBuilder().ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<TEntryPoint>());
}
