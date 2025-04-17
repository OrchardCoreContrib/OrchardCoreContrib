using OrchardCore.ContentManagement.Metadata.Builders;
using OrchardCoreContrib.ContentManagement.Metadata.Settings;

namespace OrchardCore.ContentManagement.Metadata.Settings;

/// <summary>
/// Provides a set of extensions for <see cref="ContentPartFieldDefinitionBuilder"/> to configure Time Field editor.
/// </summary>
public static class TimeFieldDefinitionBuilderExtensions
{
    /// <summary>
    /// Configures the Time Field to use the standard editor.
    /// </summary>
    /// <param name="builder"><see cref="ContentPartFieldDefinitionBuilder"/>.</param>
    public static ContentPartFieldDefinitionBuilder WithTimeFieldEditor(this ContentPartFieldDefinitionBuilder builder)
        => builder.MergeSettings<ContentPartFieldSettings>(x => x.Editor = TimeFieldEditor.Standard);
}
