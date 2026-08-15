using System.Runtime.CompilerServices;

namespace OrchardCoreContrib.Infrastructure;

/// <summary>
/// Represents an argument checker.
/// </summary>
public static partial class Guard
{
    /// <summary>
    /// Ensures that the input value must not be <see langword="null" /> or <see cref="string.Empty"/>.
    /// </summary>
    /// <param name="value">The string value to be tested.</param>
    /// <param name="name">The name of the tested value.</param>
    /// <exception cref="ArgumentNullOrEmptyException">Thrown if the value is <see langword="null" /> or <see cref="string.Empty"/>.</exception>"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ArgumentNotNullOrEmpty(string value, [CallerArgumentExpression(nameof(value))] string name = null)
        => ArgumentException.ThrowIfNullOrEmpty(value, name);

    /// <summary>
    /// Ensures that the input value must not be <see langword="null" />, <see cref="string.Empty"/>, or consist only of white-space characters.
    /// </summary>
    /// <param name="value">The string value to be tested.</param>
    /// <param name="name">The name of the tested value.</param>
    /// <exception cref="ArgumentNullException">Thrown if the value is <see langword="null" />, <see cref="string.Empty"/>, or consist only of white-space characters.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ArgumentNotNullOrWhiteSpace(string value, [CallerArgumentExpression(nameof(value))] string name = null)
        => ArgumentNullException.ThrowIfNullOrWhiteSpace(value, name);

    /// <summary>
    /// Ensures that the input value must not be <see cref="string.Empty"/>.
    /// </summary>
    /// <param name="value">The string value to be tested.</param>
    /// <param name="name">The name of the tested value.</param>
    /// <exception cref="ArgumentException">Thrown if the value is <see cref="string.Empty"/>.</exception>"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ArgumentNotEmpty(string value, [CallerArgumentExpression(nameof(value))] string name = null)
    {
        Guard.ArgumentNotNull(value, name);

        if (value == string.Empty)
        {
            throw new ArgumentException($"Value must not be empty.", name);
        }
    }

    /// <summary>
    /// Ensures that the input value does not consist only of white-space characters.
    /// </summary>
    /// <param name="value">The string value to be tested.</param>
    /// <param name="name">The name of the tested value.</param>
    /// <exception cref="ArgumentException">Thrown if the value consists only of white-space characters.</exception>"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ArgumentNotWhiteSpace(string value, [CallerArgumentExpression(nameof(value))] string name = null)
    {
        Guard.ArgumentNotNull(value, name);

        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException($"Value must not consist only of white-space characters.", name);
        }
    }
}
