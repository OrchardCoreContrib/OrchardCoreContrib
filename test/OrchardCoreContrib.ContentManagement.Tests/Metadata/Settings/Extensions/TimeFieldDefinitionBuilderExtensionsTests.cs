using OrchardCore.ContentManagement.Metadata.Builders;
using OrchardCore.ContentManagement.Metadata.Models;
using OrchardCoreContrib.ContentManagement.Helpers.Tests;
using OrchardCoreContrib.ContentManagement.Metadata.Settings;
using Xunit;

namespace OrchardCore.ContentManagement.Metadata.Settings.Tests;

public class TimeFieldDefinitionBuilderExtensionsTests
{
    private static readonly ContentPartFieldDefinitionBuilder _partFieldDefinitionBuilder = ContentPartFieldDefinitionBuilderHelper.CreateDummyPartFieldDefinitionBuilder();

    [Fact]
    public void WithTimeFieldEditor_ShouldReturnsEmpty()
    {
        // Act
        var partFieldDefinitionBuilder = _partFieldDefinitionBuilder
            .WithTimeFieldEditor();
        var partFieldDefinition = partFieldDefinitionBuilder.Build();

        // Assert
        Assert.Equal(FieldEditor.Standard, partFieldDefinition.Editor());
    }
}
