using System.Runtime.CompilerServices;

namespace OrchardCoreContrib.Infrastructure;

/// <summary>
/// Represents an argument checker.
/// </summary>
public static partial class Guard
{
    /// <summary>
    /// Throws <see cref="ArgumentNullException"/> if the given value is <see langword="null" />.
    /// </summary>
    /// <param name="value">The value to be tested.</param>
    /// <param name="name">The name of the tested value.</param>
    public static void ArgumentNotNull(object value, [CallerArgumentExpression(nameof(value))] string name = null)
    {
        if (value is null)
        {
            ArgumentNullException.ThrowIfNull(value, name);
        }
    }
}
