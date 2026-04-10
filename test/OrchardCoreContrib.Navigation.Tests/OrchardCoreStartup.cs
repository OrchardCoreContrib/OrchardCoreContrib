using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Modules;
using OrchardCore.Navigation;
using OrchardCoreContrib.Testing;
using OrchardCoreContrib.Testing.Security;

namespace OrchardCoreContrib.Navigation.Tests;

public class OrchardCoreStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddOrchardCms(builder => builder
            .AddSetupFeatures("OrchardCore.Tenants")
            .ConfigureServices(serviceCollection =>
            {
                serviceCollection.AddScoped<IAuthorizationHandler, PermissionContextAuthorizationHandler>(sp =>
                    new PermissionContextAuthorizationHandler(sp.GetRequiredService<IHttpContextAccessor>(), SiteContextOptions.PermissionsContexts));

                serviceCollection.AddNavigationProvider<TestMenu1>();
                serviceCollection.AddNavigationProvider<TestMenu2>();
                serviceCollection.AddNavigationProvider<TestMenu3>();
            })
            .Configure(appBuilder => appBuilder.UseAuthorization()));

        services.AddSingleton<IModuleNamesProvider>(new ModuleNamesProvider(typeof(Web.Program).Assembly));
    }

    public void Configure(IApplicationBuilder app) => app.UseOrchardCore();
}