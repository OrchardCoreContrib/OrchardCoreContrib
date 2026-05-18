namespace OrchardCoreContrib.Avatars;

/// <summary>
/// Represents the context information for generating an avatar, including user details such as UserId, DisplayName, and Email.
/// </summary>
public class AvatarContext
{
    /// <summary>
    /// Gets or sets the unique identifier of the user associated with the object.
    /// </summary>
    public string UserId { get; set; }

    /// <summary>
    /// Gets or sets the display name associated with the object.
    /// </summary>
    public string DisplayName { get; set; }

    /// <summary>
    /// Gets or sets the email address associated with the object.
    /// </summary>
    public string Email { get; set; }
}
