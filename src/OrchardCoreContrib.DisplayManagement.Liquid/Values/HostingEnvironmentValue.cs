using Fluid;
using Fluid.Values;
using Microsoft.Extensions.Hosting;
using System.Globalization;
using System.Text.Encodings.Web;

namespace OrchardCoreContrib.DisplayManagement.Liquid.Values;

/// <summary>
/// Represents a FluidValue wrapper for an ASP.NET Core hosting environment, exposing environment information to Fluid templates.
/// </summary>
/// <param name="hostEnvironment">The host environment instance that provides information about the current application's environment, such as its
/// name and type. Cannot be null.</param>
public class HostingEnvironmentValue(IHostEnvironment hostEnvironment) : FluidValue
{
    /// <inheritdoc/>
    public override FluidValues Type => FluidValues.Object;

    /// <inheritdoc/>
    public override bool Equals(FluidValue other)
    {
        if (other is null)
        {
            return false;
        }

        return ToStringValue(null) == other.ToStringValue(null);
    }

    /// <inheritdoc/>
    [Obsolete]
    public override bool ToBooleanValue() => true;

    /// <inheritdoc/>
    public override bool ToBooleanValue(TemplateContext context) => true;

    /// <inheritdoc/>
    [Obsolete]
    public override decimal ToNumberValue() => 0;

    /// <inheritdoc/>
    public override decimal ToNumberValue(TemplateContext context) => 0;

    /// <inheritdoc/>
    [Obsolete]
    public override object ToObjectValue() => hostEnvironment;

    /// <inheritdoc/>
    public override object ToObjectValue(TemplateContext context) => hostEnvironment;

    /// <inheritdoc/>
    [Obsolete]
    public override string ToStringValue() => hostEnvironment.EnvironmentName;

    /// <inheritdoc/>
    public override string ToStringValue(TemplateContext context) => hostEnvironment.EnvironmentName;

    /// <inheritdoc/>
    public override ValueTask WriteToAsync(IFluidOutput output, TextEncoder encoder, CultureInfo cultureInfo) => default;

    /// <inheritdoc/>
    public override ValueTask<FluidValue> GetValueAsync(string name, TemplateContext context) => name switch
    {
        "IsDevelopment" => BooleanValue.Create(hostEnvironment.IsDevelopment()),
        "IsStaging" => BooleanValue.Create(hostEnvironment.IsStaging()),
        "IsProduction" => BooleanValue.Create(hostEnvironment.IsProduction()),
        "Name" => StringValue.Create(hostEnvironment.EnvironmentName),
        _ => NilValue.Instance
    };
}
