namespace OrchardCoreContrib.Avatars;

/// <summary>
/// Represents a no-op avatar service that always returns an empty string.
/// This can be used as a default or placeholder implementation when no other services are available.
/// </summary>
public class NullAvatarService : IAvatarService
{
    /// <inheritdoc/>
    public string GetAvatar(AvatarContext context, int size = 80) => string.Empty;
}
