using OrchardCore.ContentManagement.Metadata.Builders;
using OrchardCoreContrib.ContentManagement.Metadata.Settings;

namespace OrchardCore.ContentManagement.Metadata.Settings;

/// <summary>
/// Provides a set of extensions for <see cref="ContentPartFieldDefinitionBuilder"/> to configure Content Picker Field editor.
/// </summary>
public static class ContentPickerFieldDefinitionBuilderExtensions
{
    /// <summary>
    /// Configures the Content Picker Field to use the standard editor.
    /// </summary>
    /// <param name="builder"><see cref="ContentPartFieldDefinitionBuilder"/>.</param>
    public static ContentPartFieldDefinitionBuilder WithContentPickerFieldEditor(this ContentPartFieldDefinitionBuilder builder)
        => builder.MergeSettings<ContentPartFieldSettings>(x => x.Editor = ContentPickerFieldEditor.Standard);
}
