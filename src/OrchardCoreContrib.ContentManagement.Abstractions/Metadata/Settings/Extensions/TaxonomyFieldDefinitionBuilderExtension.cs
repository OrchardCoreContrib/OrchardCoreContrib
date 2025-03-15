using OrchardCore.ContentManagement.Metadata.Builders;

namespace OrchardCore.ContentManagement.Metadata.Settings;

/// <summary>
/// Provides a set of extensions for <see cref="ContentPartFieldDefinitionBuilder"/> to configure Taxonomy Field editor.
/// </summary>
public static class TaxonomyTextFieldDefinitionBuilderExtensions
{
    /// <summary>
    /// Configures the Taxonomy Field to use the standard editor.
    /// </summary>
    /// <param name="builder"><see cref="ContentPartFieldDefinitionBuilder"/>.</param>
    public static ContentPartFieldDefinitionBuilder WithTaxonomyFieldEditor(this ContentPartFieldDefinitionBuilder builder)
            => builder.MergeSettings<ContentPartFieldSettings>(x => x.Editor = TaxonomyFieldEditor.Standard);

    /// <summary>
    /// Configures the Taxonomy Field to use the tags editor.
    /// </summary>
    /// <param name="builder"><see cref="ContentPartFieldDefinitionBuilder"/>.</param>
    public static ContentPartFieldDefinitionBuilder WithTaxonomyFieldTagsEditor(this ContentPartFieldDefinitionBuilder builder)
        => builder.MergeSettings<ContentPartFieldSettings>(x => x.Editor = TaxonomyFieldEditor.Tags);
}
