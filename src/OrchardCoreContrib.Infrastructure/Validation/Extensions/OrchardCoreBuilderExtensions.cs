using Microsoft.Extensions.DependencyInjection;

namespace OrchardCoreContrib.Validation;

/// <summary>
/// Provides an extension methods for <see cref="OrchardCoreBuilder"/>.
/// </summary>
public static class OrchardCoreBuilderExtensions
{
    /// <summary>
    /// Adds phone number validator service.
    /// </summary>
    /// <param name="builder">The <see cref="OrchardCoreBuilder"/>.</param>
    public static OrchardCoreBuilder AddPhoneNumberValidator(this OrchardCoreBuilder builder)
    {
        builder.ConfigureServices(services =>
            services.AddTransient<IPhoneNumberValidator, PhoneNumberValidator>());

        return builder;
    }
}
