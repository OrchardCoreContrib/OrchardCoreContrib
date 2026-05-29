using System.Runtime.CompilerServices;

namespace OrchardCoreContrib.Infrastructure;

/// <summary>
/// Represents an argument checker for collections.
/// </summary>
public static partial class Guard
{
    /// <summary>
    /// Throws <see cref="ArgumentNullOrEmptyException"/> if the given collection is <see langword="null" /> or empty.
    /// </summary>
    /// <param name="value">The collection to be tested.</param>
    /// <param name="name">The name of the tested collection.</param>
    public static void ArgumentNotNullOrEmpty(IEnumerable<object> value, [CallerArgumentExpression(nameof(value))] string name = null)
    {
        if (value is null || !value.Any())
        {
            throw new ArgumentNullOrEmptyException(name);
        }
    }
}
