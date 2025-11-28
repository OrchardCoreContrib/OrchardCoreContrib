using Fluid;
using Fluid.Values;
using Microsoft.Extensions.Hosting;
using Moq;
using System.Globalization;
using System.Text.Encodings.Web;
using Xunit;

namespace OrchardCoreContrib.DisplayManagement.Liquid.Values.Tests;


public class HostingEnvironmentValueTests
{
    [Fact]
    public void Type_IsObject()
    {
        // Arrange
        var hostEnvironmentValue = GetHostEnvironmentValue(Environments.Development, out _);

        // Act & Assert
        Assert.Equal(FluidValues.Object, hostEnvironmentValue.Type);
    }

    [Fact]
    public void ToStringValue_ToObjectValue_ToBoolean_ToNumber()
    {
        // Arrange
        var environmentName = "env";
        var hostEnvironmentValue = GetHostEnvironmentValue(environmentName, out IHostEnvironment hostEnvironment);

        // Act & Assert
        Assert.Equal(environmentName, hostEnvironmentValue.ToStringValue());
        Assert.Same(hostEnvironment, hostEnvironmentValue.ToObjectValue());
        Assert.True(hostEnvironmentValue.ToBooleanValue());
        Assert.Equal(0m, hostEnvironmentValue.ToNumberValue());
    }

    [Fact]
    public void Equals_WorksWithNullAndMatchingValues()
    {
        //// Arrange
        var environmentName = "env";
        var hostEnvironmentValue = GetHostEnvironmentValue(environmentName);
        var otherHostEnvironmentValue = GetHostEnvironmentValue(environmentName);

        // Act & Assert
        Assert.False(hostEnvironmentValue.Equals(null));
        Assert.True(hostEnvironmentValue.Equals(StringValue.Create(environmentName)));
        Assert.True(hostEnvironmentValue.Equals(otherHostEnvironmentValue));
    }

    [Fact]
    public async Task WriteToAsync_WritesEnvironmentName()
    {
        // Arrange
        var environmentName = "env";
        var hostEnvironmentValue = GetHostEnvironmentValue(environmentName);

        // Act
        using var writer = new StringWriter();
        await hostEnvironmentValue.WriteToAsync(writer, HtmlEncoder.Default, CultureInfo.InvariantCulture);

        // Assert
        Assert.Equal(environmentName, writer.ToString());
    }

    [InlineData("Development", true, false, false)]
    [InlineData("Staging", false, true, false)]
    [InlineData("production", false, false, true)]
    [Theory]
    public async Task GetValueAsync_ReturnsExpectedProperties(string environmentName, bool isDevelopment, bool isStaging, bool isProduction)
    {
        // Arrange
        var hostEnvironmentValue = GetHostEnvironmentValue(environmentName);

        // Act
        var isDevelopmentValue = await hostEnvironmentValue.GetValueAsync("IsDevelopment", new TemplateContext());
        var isStagingValue = await hostEnvironmentValue.GetValueAsync("IsStaging", new TemplateContext());
        var isProductionValue = await hostEnvironmentValue.GetValueAsync("IsProduction", new TemplateContext());
        var environmentNameValue = await hostEnvironmentValue.GetValueAsync("Name", new TemplateContext());
        var unknownValue = await hostEnvironmentValue.GetValueAsync("DoesNotExist", new TemplateContext());

        // Assert
        Assert.Equal(isDevelopment, ((BooleanValue)isDevelopmentValue).ToBooleanValue());
        Assert.Equal(isStaging, ((BooleanValue)isStagingValue).ToBooleanValue());
        Assert.Equal(isProduction, ((BooleanValue)isProductionValue).ToBooleanValue());
        Assert.Equal(environmentName, ((StringValue)environmentNameValue).ToStringValue());
        Assert.Same(NilValue.Instance, unknownValue);
    }

    private static HostingEnvironmentValue GetHostEnvironmentValue(string environmentName)
        => GetHostEnvironmentValue(environmentName, out _);

    private static HostingEnvironmentValue GetHostEnvironmentValue(string environmentName, out IHostEnvironment hostEnvironment)
    {
        var hostEnvironmentMock = new Mock<IHostEnvironment>();
        hostEnvironmentMock.SetupGet(h => h.EnvironmentName)
            .Returns(environmentName);

        hostEnvironment = hostEnvironmentMock.Object;

        return new HostingEnvironmentValue(hostEnvironment);
    }
}
