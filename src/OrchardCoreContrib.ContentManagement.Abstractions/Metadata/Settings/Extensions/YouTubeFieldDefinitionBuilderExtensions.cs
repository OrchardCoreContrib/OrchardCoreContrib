using OrchardCore.ContentManagement.Metadata.Builders;
using OrchardCoreContrib.ContentManagement.Metadata.Settings;

namespace OrchardCore.ContentManagement.Metadata.Settings;

/// <summary>
/// Provides a set of extensions for <see cref="ContentPartFieldDefinitionBuilder"/> to configure YouTube Field editor.
/// </summary>
public static class YouTubeFieldDefinitionBuilderExtensions
{
    /// <summary>
    /// Configures the YouTube Field to use the standard editor.
    /// </summary>
    /// <param name="builder"><see cref="ContentPartFieldDefinitionBuilder"/>.</param>
    public static ContentPartFieldDefinitionBuilder WithYouTubeFieldEditor(this ContentPartFieldDefinitionBuilder builder)
        => builder.MergeSettings<ContentPartFieldSettings>(x => x.Editor = YouTubeFieldEditor.Standard);
}
