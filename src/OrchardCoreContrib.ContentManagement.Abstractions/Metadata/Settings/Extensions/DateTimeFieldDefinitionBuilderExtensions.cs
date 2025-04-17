using OrchardCore.ContentManagement.Metadata.Builders;
using OrchardCoreContrib.ContentManagement.Metadata.Settings;

namespace OrchardCore.ContentManagement.Metadata.Settings;

/// <summary>
/// Provides a set of extensions for <see cref="ContentPartFieldDefinitionBuilder"/> to configure Date Time Field editor.
/// </summary>
public static class DateTimeFieldDefinitionBuilderExtensions
{
    /// <summary>
    /// Configures the Date Time Field to use the standard editor.
    /// </summary>
    /// <param name="builder"><see cref="ContentPartFieldDefinitionBuilder"/>.</param>
    public static ContentPartFieldDefinitionBuilder WithDateTimeFieldEditor(this ContentPartFieldDefinitionBuilder builder)
        => builder.MergeSettings<ContentPartFieldSettings>(x => x.Editor = DateTimeFieldEditor.Standard);
}
