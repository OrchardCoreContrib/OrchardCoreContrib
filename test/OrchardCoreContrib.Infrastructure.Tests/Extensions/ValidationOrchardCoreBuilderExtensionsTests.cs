using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Modules;
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
        var result = ValidationOrchardCoreBuilderExtensions.AddPhoneNumberValidator(builder);

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
        ValidationOrchardCoreBuilderExtensions.AddPhoneNumberValidator(builder);

        var serviceProvider = services.BuildServiceProvider();

        var startup = serviceProvider.GetService<IStartup>();

        startup.ConfigureServices(services);

        // Assert
        var descriptor = Assert.Single(services, d => d.ServiceType == typeof(IPhoneNumberValidator));
        Assert.Equal(ServiceLifetime.Transient, descriptor.Lifetime);
        Assert.Equal(typeof(PhoneNumberValidator), descriptor.ImplementationType);

        serviceProvider = services.BuildServiceProvider();

        var first = serviceProvider.GetService<IPhoneNumberValidator>();
        var second = serviceProvider.GetService<IPhoneNumberValidator>();

        Assert.NotSame(first, second);
    }
}
