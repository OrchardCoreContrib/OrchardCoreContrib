﻿namespace OrchardCore.ContentManagement.Metadata.Settings;

/// <summary>
/// Contains a list of the Numeric Field editors.
/// </summary>
public sealed class NumericFieldEditor
{
    /// <summary>
    /// The standard numeric field editor.
    /// </summary>
    public const string Standard = "";
    /// <summary>
    /// The range numeric field editor.
    /// </summary>
    public const string Range = "Range";
    /// <summary>
    /// The select numeric field editor.
    /// </summary>
    public const string Select = "Select";
    /// <summary>
    /// The slider numeric field editor.
    /// </summary>
    public const string Slider = "Slider";
    /// <summary>
    /// The spinner numeric field editor.
    /// </summary>
    public const string Spinner = "Spinner";
}
