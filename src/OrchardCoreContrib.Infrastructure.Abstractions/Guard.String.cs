using System.Runtime.CompilerServices;

namespace OrchardCoreContrib.Infrastructure;

/// <summary>
/// Represents an argument checker for <see cref="String"/>.
/// </summary>
public static partial class Guard
{
    /// <summary>
    /// Throws <see cref="ArgumentNullOrEmptyException"/> if the given string value is <see langword="null" /> or <see cref="string.Empty"/>.
    /// </summary>
    /// <param name="value">The string value to be tested.</param>
    /// <param name="name">The name of the tested value.</param>
    public static void ArgumentNotNullOrEmpty(string value, [CallerArgumentExpression(nameof(value))] string name = null)
    {
        if (String.IsNullOrEmpty(value))
        {
            throw new ArgumentNullOrEmptyException(name);
        }
    }
}
