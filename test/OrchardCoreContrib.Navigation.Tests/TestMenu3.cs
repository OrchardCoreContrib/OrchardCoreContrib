using Microsoft.Extensions.Localization;
using OrchardCore.Navigation;

namespace OrchardCoreContrib.Navigation.Tests;

public class TestMenu3(IStringLocalizer<TestMenu3> S) : NavigationProvider
{
    public override string Name => nameof(TestMenu3);

    public override Task BuildNavigationAsync(NavigationBuilder builder)
    {
        builder
            .Add(S["Test"], test => test
                .Add(S["Item 1"], item1 => item1
                    .Url("#")
                    .Tenants(["TestTenant1", "TestTenant2"])
                )
            );

        return Task.CompletedTask;
    }
}
