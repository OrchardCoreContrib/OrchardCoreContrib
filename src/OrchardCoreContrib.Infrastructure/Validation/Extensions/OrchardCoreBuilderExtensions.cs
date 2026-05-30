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
    [Obsolete("This method is deprecated and will be removed in the upcoming major release.", error: true)]
    public static OrchardCoreBuilder AddPhoneNumberValidator(this OrchardCoreBuilder builder)
        => ValidationOrchardCoreBuilderExtensions.AddPhoneNumberValidator(builder);
}
