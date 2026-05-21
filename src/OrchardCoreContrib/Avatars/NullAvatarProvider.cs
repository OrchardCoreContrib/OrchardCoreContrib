namespace OrchardCoreContrib.Avatars;

/// <summary>
/// Represents a no-op avatar provider that always returns an empty string.
/// This can be used as a default or placeholder implementation when no other providers are available.
/// </summary>
public class NullAvatarProvider : IAvatarProvider
{
    /// <inheritdoc/>
    public string GetAvatar(AvatarContext context, int size = 80) => string.Empty;
}
