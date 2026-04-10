using Microsoft.Extensions.Localization;
using OrchardCore.Navigation;

namespace OrchardCoreContrib.Navigation.Tests;

public class TestMenu1(IStringLocalizer<TestMenu1> S) : NavigationProvider
{
    public override string Name => nameof(TestMenu1);

    public override Task BuildNavigationAsync(NavigationBuilder builder)
    {
        builder
            .Add(S["Test"], test => test
                .Add(S["Item 1"], item1 => item1
                    .Url("#")
                    .Tenant("TestTenant")
                )
            );

        return Task.CompletedTask;
    }
}
