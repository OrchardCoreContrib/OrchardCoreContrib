using Microsoft.Extensions.Localization;
using OrchardCore.Navigation;

namespace OrchardCoreContrib.Navigation.Tests;

public class TestMenu2(IStringLocalizer<TestMenu2> S) : NavigationProvider
{
    public override string Name => nameof(TestMenu2);

    public override Task BuildNavigationAsync(NavigationBuilder builder)
    {
        builder
            .Add(S["Test"], test => test
                .Add(S["Item 1"], item1 => item1
                    .Url("#")
                    .Tenant(t => t.StartsWith("TestTenant"))
                )
            );

        return Task.CompletedTask;
    }
}
