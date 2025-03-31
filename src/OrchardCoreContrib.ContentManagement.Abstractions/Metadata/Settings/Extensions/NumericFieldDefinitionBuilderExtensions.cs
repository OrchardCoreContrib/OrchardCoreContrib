using OrchardCore.ContentManagement.Metadata.Builders;
using OrchardCoreContrib.ContentManagement.Metadata.Settings;

namespace OrchardCore.ContentManagement.Metadata.Settings;

/// <summary>
/// Provides a set of extensions for <see cref="ContentPartFieldDefinitionBuilder"/> to configure Numeric Field editor.
/// </summary>
public static class NumericTextFieldDefinitionBuilderExtensions
{
    /// <summary>
    /// Configures the Numeric Field to use the standard editor.
    /// </summary>
    /// <param name="builder"><see cref="ContentPartFieldDefinitionBuilder"/>.</param>
    public static ContentPartFieldDefinitionBuilder WithNumericFieldEditor(this ContentPartFieldDefinitionBuilder builder)
            => builder.MergeSettings<ContentPartFieldSettings>(x => x.Editor = NumericFieldEditor.Standard);

    /// <summary>
    /// Configures the Numeric Field to use the range editor.
    /// </summary>
    /// <param name="builder"><see cref="ContentPartFieldDefinitionBuilder"/>.</param>
    public static ContentPartFieldDefinitionBuilder WithNumericFieldRangeEditor(this ContentPartFieldDefinitionBuilder builder)
        => builder.MergeSettings<ContentPartFieldSettings>(x => x.Editor = NumericFieldEditor.Range);

    /// <summary>
    /// Configures the Numeric Field to use the select editor.
    /// </summary>
    /// <param name="builder"><see cref="ContentPartFieldDefinitionBuilder"/>.</param>
    public static ContentPartFieldDefinitionBuilder WithNumericFieldSelectEditor(this ContentPartFieldDefinitionBuilder builder)
        => builder.MergeSettings<ContentPartFieldSettings>(x => x.Editor = NumericFieldEditor.Select);

    /// <summary>
    /// Configures the Numeric Field to use the slider editor.
    /// </summary>
    /// <param name="builder"><see cref="ContentPartFieldDefinitionBuilder"/>.</param>
    public static ContentPartFieldDefinitionBuilder WithNumericFieldSliderEditor(this ContentPartFieldDefinitionBuilder builder)
        => builder.MergeSettings<ContentPartFieldSettings>(x => x.Editor = NumericFieldEditor.Slider);

    /// <summary>
    /// Configures the Numeric Field to use the spinner editor.
    /// </summary>
    /// <param name="builder"><see cref="ContentPartFieldDefinitionBuilder"/>.</param>
    public static ContentPartFieldDefinitionBuilder WithNumericFieldSpinnerEditor(this ContentPartFieldDefinitionBuilder builder)
        => builder.MergeSettings<ContentPartFieldSettings>(x => x.Editor = NumericFieldEditor.Spinner);
}
