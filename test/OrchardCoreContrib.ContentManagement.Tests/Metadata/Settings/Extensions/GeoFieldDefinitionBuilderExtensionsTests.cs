using OrchardCore.ContentManagement.Metadata.Builders;
using OrchardCore.ContentManagement.Metadata.Models;
using OrchardCoreContrib.ContentManagement.Helpers.Tests;
using OrchardCoreContrib.ContentManagement.Metadata.Settings;
using Xunit;

namespace OrchardCore.ContentManagement.Metadata.Settings.Tests;

public class GeoFieldDefinitionBuilderExtensionsTests
{
    private static readonly ContentPartFieldDefinitionBuilder _partFieldDefinitionBuilder = ContentPartFieldDefinitionBuilderHelper.CreateDummyPartFieldDefinitionBuilder();

    [Fact]
    public void WithGeoFieldEditor_ShouldReturnsEmpty()
    {
        // Act
        var partFieldDefinitionBuilder = _partFieldDefinitionBuilder
            .WithGeoFieldEditor();
        var partFieldDefinition = partFieldDefinitionBuilder.Build();

        // Assert
        Assert.Equal(FieldEditor.Standard, partFieldDefinition.Editor());
    }

    [Fact]
    public void WithGeoFieldLeafletEditor_ShouldReturnsSwitch()
    {
        // Act
        var partFieldDefinitionBuilder = _partFieldDefinitionBuilder
            .WithGeoFieldLeafletEditor();
        var partFieldDefinition = partFieldDefinitionBuilder.Build();

        // Assert
        Assert.Equal("Leaflet", partFieldDefinition.Editor());
    }
}
