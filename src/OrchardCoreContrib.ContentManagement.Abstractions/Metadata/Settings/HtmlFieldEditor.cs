namespace OrchardCoreContrib.ContentManagement.Metadata.Settings;

/// <summary>
/// Contains a list of the HTML Field editors.
/// </summary>
public sealed class HtmlFieldEditor : FieldEditor
{
    /// <summary>
    /// The Wysiwyg HTML field editor.
    /// </summary>
    public const string Wysiwyg = "Wysiwyg";
    /// <summary>
    /// The Trumbowyg HTML field editor.
    /// </summary>
    public const string Trumbowyg = "Trumbowyg";
    /// <summary>
    /// The Monaco HTML field editor.
    /// </summary>
    public const string Monaco = "Monaco";
    /// <summary>
    /// The multi-line HTML field editor.
    /// </summary>
    public const string Multiline = "Multiline";
}
