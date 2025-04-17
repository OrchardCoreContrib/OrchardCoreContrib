using OrchardCore.ContentManagement.Metadata.Builders;
using OrchardCoreContrib.ContentManagement.Metadata.Settings;

namespace OrchardCore.ContentManagement.Metadata.Settings;

/// <summary>
/// Provides a set of extensions for <see cref="ContentPartFieldDefinitionBuilder"/> to configure Link Field editor.
/// </summary>
public static class LinkFieldDefinitionBuilderExtensions
{
    /// <summary>
    /// Configures the Link Field to use the standard editor.
    /// </summary>
    /// <param name="builder"><see cref="ContentPartFieldDefinitionBuilder"/>.</param>
    public static ContentPartFieldDefinitionBuilder WithLinkFieldEditor(this ContentPartFieldDefinitionBuilder builder)
        => builder.MergeSettings<ContentPartFieldSettings>(x => x.Editor = LinkFieldEditor.Standard);
}
