namespace OrchardCoreContrib.ContentManagement.Metadata.Settings;

/// <summary>
/// Contains a list of the Text Field editors.
/// </summary>
public sealed class TextFieldEditor : FieldEditor
{
    /// <summary>
    /// The CodeMirror text field editor.
    /// </summary>
    public const string CodeMirror = "CodeMirror";
    /// <summary>
    /// The Color text field editor.
    /// </summary>
    public const string Color = "Color";
    /// <summary>
    /// The email text field editor.
    /// </summary>
    public const string Email = "Email";
    /// <summary>
    /// The icon picker text field editor.
    /// </summary>
    public const string IconPicker = "IconPicker";
    /// <summary>
    /// The Monaco text field editor.
    /// </summary>
    public const string Monaco = "Monaco";
    /// <summary>
    /// The predefined list text field editor.
    /// </summary>
    public const string PredefinedList = "PredefinedList";
    /// <summary>
    /// The phone text field editor.
    /// </summary>
    public const string Phone = "Tel";
    /// <summary>
    /// The text area text field editor.
    /// </summary>
    public const string MultiLine = "TextArea";
    /// <summary>
    /// The URL text field editor.
    /// </summary>
    public const string Url = "Url";
}
