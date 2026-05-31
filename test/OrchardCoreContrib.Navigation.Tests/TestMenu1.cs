using Microsoft.Extensions.Localization;
using OrchardCore.Navigation;

namespace OrchardCoreContrib.Navigation.Tests;

public class TestMenu1(IStringLocalizer<TestMenu1>? localizer) : NavigationProvider
{
    private readonly IStringLocalizer<TestMenu1>? _localizer = localizer;

    public override string Name => nameof(TestMenu1);

    public override Task BuildNavigationAsync(NavigationBuilder builder)
    {
        builder
            .Add(_localizer?["Test"] ?? new LocalizedString("Test", "Test"), test => test
                .Add(_localizer?["Item 1"] ?? new LocalizedString("Item 1", "Item 1"), item1 => item1
                    .Url("#")
                    .Tenant("TestTenant")
                )
            );

        return Task.CompletedTask;
    }
}
