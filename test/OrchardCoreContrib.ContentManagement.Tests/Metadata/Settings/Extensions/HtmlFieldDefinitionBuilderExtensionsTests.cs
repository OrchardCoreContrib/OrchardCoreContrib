using OrchardCore.ContentManagement.Metadata.Builders;
using OrchardCore.ContentManagement.Metadata.Models;
using OrchardCoreContrib.ContentManagement.Helpers.Tests;
using OrchardCoreContrib.ContentManagement.Metadata.Settings;
using Xunit;

namespace OrchardCore.ContentManagement.Metadata.Settings.Tests;

public class HtmlFieldDefinitionBuilderExtensionsTests
{
    private static readonly ContentPartFieldDefinitionBuilder _partFieldDefinitionBuilder = ContentPartFieldDefinitionBuilderHelper.CreateDummyPartFieldDefinitionBuilder();
    
    [Fact]
    public void WithHtmlFieldEditor_ShouldReturnsEmpty()
    {
        // Act
        var partFieldDefinitionBuilder = _partFieldDefinitionBuilder
            .WithHtmlFieldEditor();
        var partFieldDefinition = partFieldDefinitionBuilder.Build();

        // Assert
        Assert.Equal(FieldEditor.Standard, partFieldDefinition.Editor());
    }

    [Fact]
    public void WithHtmlFieldMonacoEditor_ShouldReturnsMonaco()
    {
        // Act
        var partFieldDefinitionBuilder = _partFieldDefinitionBuilder
            .WithHtmlFieldMonacoEditor();
        var partFieldDefinition = partFieldDefinitionBuilder.Build();

        // Assert
        Assert.Equal("Monaco", partFieldDefinition.Editor());
    }

    [Fact]
    public void WithHtmlFieldMultilineEditor_ShouldReturnsMultiline()
    {
        // Act
        var partFieldDefinitionBuilder = _partFieldDefinitionBuilder
            .WithHtmlFieldMultilineEditor();
        var partFieldDefinition = partFieldDefinitionBuilder.Build();

        // Assert
        Assert.Equal("Multiline", partFieldDefinition.Editor());
    }

    [Fact]
    public void WithHtmlFieldTrumbowygEditor_ShouldReturnsTrumbowyg()
    {
        // Act
        var partFieldDefinitionBuilder = _partFieldDefinitionBuilder
            .WithHtmlFieldTrumbowygEditor();
        var partFieldDefinition = partFieldDefinitionBuilder.Build();

        // Assert
        Assert.Equal("Trumbowyg", partFieldDefinition.Editor());
    }

    [Fact]
    public void WithHtmlFieldWysiwygEditor_ShouldReturnsWysiwyg()
    {
        // Act
        var partFieldDefinitionBuilder = _partFieldDefinitionBuilder
            .WithHtmlFieldWysiwygEditor();
        var partFieldDefinition = partFieldDefinitionBuilder.Build();

        // Assert
        Assert.Equal("Wysiwyg", partFieldDefinition.Editor());
    }
}
