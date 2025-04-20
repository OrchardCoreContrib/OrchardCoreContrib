using OrchardCore.ContentManagement.Metadata.Builders;
using OrchardCore.ContentManagement.Metadata.Models;
using OrchardCoreContrib.ContentManagement.Helpers.Tests;
using OrchardCoreContrib.ContentManagement.Metadata.Settings;
using Xunit;

namespace OrchardCore.ContentManagement.Metadata.Settings.Tests;

public class TextFieldDefinitionBuilderExtensionsTests
{
    private static readonly ContentPartFieldDefinitionBuilder _partFieldDefinitionBuilder = ContentPartFieldDefinitionBuilderHelper.CreateDummyPartFieldDefinitionBuilder();

    [Fact]
    public void WithTextFieldEditor_ShouldReturnsEmpty()
    {
        // Act
        var partFieldDefinitionBuilder = _partFieldDefinitionBuilder
            .WithTextFieldEditor();
        var partFieldDefinition = partFieldDefinitionBuilder.Build();

        // Assert
        Assert.Equal(FieldEditor.Standard, partFieldDefinition.Editor());
    }

    [Fact]
    public void WithTextFieldCodeMirrorEditor_ShouldReturnsCodeMirror()
    {
        // Act
        var partFieldDefinitionBuilder = _partFieldDefinitionBuilder
            .WithTextFieldCodeMirrorEditor();
        var partFieldDefinition = partFieldDefinitionBuilder.Build();

        // Assert
        Assert.Equal("CodeMirror", partFieldDefinition.Editor());
    }

    [Fact]
    public void WithTextFieldColorEditor_ShouldReturnsColor()
    {
        // Act
        var partFieldDefinitionBuilder = _partFieldDefinitionBuilder
            .WithTextFieldColorEditor();
        var partFieldDefinition = partFieldDefinitionBuilder.Build();

        // Assert
        Assert.Equal("Color", partFieldDefinition.Editor());
    }

    [Fact]
    public void WithTextFieldEmailEditor_ShouldReturnsEmail()
    {
        // Act
        var partFieldDefinitionBuilder = _partFieldDefinitionBuilder
            .WithTextFieldEmailEditor();
        var partFieldDefinition = partFieldDefinitionBuilder.Build();

        // Assert
        Assert.Equal("Email", partFieldDefinition.Editor());
    }

    [Fact]
    public void WithTextFieldIconPickerEditor_ShouldReturnsIconPicker()
    {
        // Act
        var partFieldDefinitionBuilder = _partFieldDefinitionBuilder
            .WithTextFieldIconPickerEditor();
        var partFieldDefinition = partFieldDefinitionBuilder.Build();

        // Assert
        Assert.Equal("IconPicker", partFieldDefinition.Editor());
    }

    [Fact]
    public void WithTextFieldMonacoEditor_ShouldReturnsMonaco()
    {
        // Act
        var partFieldDefinitionBuilder = _partFieldDefinitionBuilder
            .WithTextFieldMonacoEditor();
        var partFieldDefinition = partFieldDefinitionBuilder.Build();

        // Assert
        Assert.Equal("Monaco", partFieldDefinition.Editor());
    }

    [Fact]
    public void WithTextFieldMultiLineEditor_ShouldReturnsTextArea()
    {
        // Act
        var partFieldDefinitionBuilder = _partFieldDefinitionBuilder
            .WithTextFieldMultiLineEditor();
        var partFieldDefinition = partFieldDefinitionBuilder.Build();

        // Assert
        Assert.Equal("TextArea", partFieldDefinition.Editor());
    }

    [Fact]
    public void WithTextFieldPhoneEditor_ShouldReturnsTel()
    {
        // Act
        var partFieldDefinitionBuilder = _partFieldDefinitionBuilder
            .WithTextFieldPhoneEditor();
        var partFieldDefinition = partFieldDefinitionBuilder.Build();

        // Assert
        Assert.Equal("Tel", partFieldDefinition.Editor());
    }

    [Fact]
    public void WithTextFieldPredefinedListEditor_ShouldReturnsPredefinedList()
    {
        // Act
        var partFieldDefinitionBuilder = _partFieldDefinitionBuilder
            .WithTextFieldPredefinedListEditor();
        var partFieldDefinition = partFieldDefinitionBuilder.Build();

        // Assert
        Assert.Equal("PredefinedList", partFieldDefinition.Editor());
    }

    [Fact]
    public void WithTextFieldUrlEditor_ShouldReturnsUrl()
    {
        // Act
        var partFieldDefinitionBuilder = _partFieldDefinitionBuilder
            .WithTextFieldUrlEditor();
        var partFieldDefinition = partFieldDefinitionBuilder.Build();

        // Assert
        Assert.Equal("Url", partFieldDefinition.Editor());
    }
}
