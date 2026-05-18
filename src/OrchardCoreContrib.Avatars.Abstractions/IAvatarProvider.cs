namespace OrchardCoreContrib.Avatars;

/// <summary>
/// Contract for providing avatar representations based on user information.
/// </summary>
public interface IAvatarProvider
{
    /// <summary>
    /// Returns a string representing the avatar.
    /// </summary>
    /// <param name="context">The avatar context containing user information.</param>
    /// <param name="size">Optional size of the avatar image.</param>
    /// <returns>Could be a URL, a file path, or a Base64 inline image.</returns>
    string GetAvatar(AvatarContext context, int size = 80);
}