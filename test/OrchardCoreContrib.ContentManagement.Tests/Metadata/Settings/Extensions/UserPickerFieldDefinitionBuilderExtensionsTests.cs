using OrchardCore.ContentManagement.Metadata.Builders;
using OrchardCore.ContentManagement.Metadata.Models;
using OrchardCoreContrib.ContentManagement.Helpers.Tests;
using OrchardCoreContrib.ContentManagement.Metadata.Settings;
using Xunit;

namespace OrchardCore.ContentManagement.Metadata.Settings.Tests;

public class UserPickerFieldDefinitionBuilderExtensionsTests
{
    private static readonly ContentPartFieldDefinitionBuilder _partFieldDefinitionBuilder = ContentPartFieldDefinitionBuilderHelper.CreateDummyPartFieldDefinitionBuilder();

    [Fact]
    public void WithUserPickerFieldEditor_ShouldReturnsEmpty()
    {
        // Act
        var partFieldDefinitionBuilder = _partFieldDefinitionBuilder
            .WithUserPickerFieldEditor();
        var partFieldDefinition = partFieldDefinitionBuilder.Build();

        // Assert
        Assert.Equal(FieldEditor.Standard, partFieldDefinition.Editor());
    }
}
