using OrchardCore.ContentManagement.Metadata.Builders;
using OrchardCore.ContentManagement.Metadata.Models;
using OrchardCore.ContentManagement.Utilities;

namespace OrchardCoreContrib.ContentManagement.Tests;

internal class ContentPartFieldDefinitionBuilderImpl(ContentPartFieldDefinition field, ContentPartDefinition part)
        : ContentPartFieldDefinitionBuilder(field)
{
    private ContentFieldDefinition _fieldDefinition = field.FieldDefinition;
    private readonly string _fieldName = field.Name;

    public override ContentPartFieldDefinition Build()
    {
        if (!char.IsLetter(_fieldName[0]))
        {
            throw new ArgumentException("Content field name must start with a letter", "name");
        }

        if (!string.Equals(_fieldName, _fieldName.ToSafeName(), StringComparison.OrdinalIgnoreCase))
        {
            throw new ArgumentException("Content field name contains invalid characters", "name");
        }

        return new ContentPartFieldDefinition(_fieldDefinition, _fieldName, _settings);
    }

    public override string Name => _fieldName;

    public override string FieldType => _fieldDefinition.Name;


    public override string PartName => part.Name;

    public override ContentPartFieldDefinitionBuilder OfType(ContentFieldDefinition fieldDefinition)
    {
        _fieldDefinition = fieldDefinition;

        return this;
    }

    public override ContentPartFieldDefinitionBuilder OfType(string fieldType)
    {
        _fieldDefinition = new ContentFieldDefinition(fieldType);

        return this;
    }
}
