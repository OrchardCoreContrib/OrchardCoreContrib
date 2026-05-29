using Microsoft.Extensions.DependencyInjection;
using OrchardCoreContrib.Validation;
using Xunit;

namespace OrchardCoreContrib.Infrastructure.Extensions.Tests;

public class ValidationOrchardCoreBuilderExtensionsTests
{
    [Fact]
    public void AddPhoneNumberValidator_ReturnsSameBuilder()
    {
        // Arrange
        var services = new ServiceCollection();
        var builder = new OrchardCoreBuilder(services);

        // Act
        var result = builder.AddPhoneNumberValidator();

        // Assert
        Assert.Same(builder, result);
    }

    [Fact]
    public void AddPhoneNumberValidator_RegistersTransientPhoneNumberValidator()
    {
        // Arrange
        var services = new ServiceCollection();
        var builder = new OrchardCoreBuilder(services);

        // Act
        builder.AddPhoneNumberValidator();

        // Assert
        var descriptor = Assert.Single(services, d => d.ServiceType == typeof(IPhoneNumberValidator));
        Assert.Equal(ServiceLifetime.Transient, descriptor.Lifetime);
        Assert.Equal(typeof(PhoneNumberValidator), descriptor.ImplementationType);

        using var provider = services.BuildServiceProvider();
        var first = provider.GetRequiredService<IPhoneNumberValidator>();
        var second = provider.GetRequiredService<IPhoneNumberValidator>();

        Assert.NotSame(first, second);
    }
}
