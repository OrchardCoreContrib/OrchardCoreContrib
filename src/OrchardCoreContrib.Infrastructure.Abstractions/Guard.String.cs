using System.Runtime.CompilerServices;

namespace OrchardCoreContrib.Infrastructure;

/// <summary>
/// Represents an argument checker.
/// </summary>
public static partial class Guard
{
    /// <summary>
    /// Asserts that the input value must be <see langword="null" /> or <see cref="string.Empty"/>.
    /// </summary>
    /// <param name="value">The string value to be tested.</param>
    /// <param name="name">The name of the tested value.</param>
    /// <exception cref="ArgumentNullOrEmptyException">Thrown if the value is not <see langword="null" /> or <see cref="string.Empty"/>.</exception>"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ArgumentIsNullOrEmpty(string value, [CallerArgumentExpression(nameof(value))] string name = null)
    {
        if (!string.IsNullOrEmpty(value))
        {
            throw new ArgumentNullOrEmptyException(name, $"Value must be null or empty.");
        }
    }

    /// <summary>
    /// Asserts that the input value must not be <see langword="null" /> or <see cref="string.Empty"/>.
    /// </summary>
    /// <param name="value">The string value to be tested.</param>
    /// <param name="name">The name of the tested value.</param>
    /// <exception cref="ArgumentNullOrEmptyException">Thrown if the value is <see langword="null" /> or <see cref="string.Empty"/>.</exception>"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ArgumentNotNullOrEmpty(string value, [CallerArgumentExpression(nameof(value))] string name = null)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentNullOrEmptyException(name, $"Value must not be null or empty.");
        }
    }

    /// <summary>
    /// Asserts that the input value must be <see langword="null" />, <see cref="string.Empty"/>, or consist only of white-space characters.
    /// </summary>
    /// <param name="value">The string value to be tested.</param>
    /// <param name="name">The name of the tested value.</param>
    /// <exception cref="ArgumentNullException">Thrown if the value is not <see langword="null" />, <see cref="string.Empty"/>, or consist only of white-space characters.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ArgumentIsNullOrWhiteSpace(string value, [CallerArgumentExpression(nameof(value))] string name = null)
    {
        if (!string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentNullException(name, $"Value must be null, empty, or consist only of white-space characters.");
        }
    }

    /// <summary>
    /// Asserts that the input value must not be <see langword="null" />, <see cref="string.Empty"/>, or consist only of white-space characters.
    /// </summary>
    /// <param name="value">The string value to be tested.</param>
    /// <param name="name">The name of the tested value.</param>
    /// <exception cref="ArgumentNullException">Thrown if the value is <see langword="null" />, <see cref="string.Empty"/>, or consist only of white-space characters.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ArgumentIsNotNullOrWhiteSpace(string value, [CallerArgumentExpression(nameof(value))] string name = null)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(value);
        }
    }

    /// <summary>
    /// Asserts that the input value must be <see cref="string.Empty"/>.
    /// </summary>
    /// <param name="value">The string value to be tested.</param>
    /// <param name="name">The name of the tested value.</param>
    /// <exception cref="ArgumentException">Thrown if the value is not <see cref="string.Empty"/>.</exception>"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ArgumentIsEmpty(string value, [CallerArgumentExpression(nameof(value))] string name = null)
    {
        if (value != string.Empty)
        {
            throw new ArgumentException($"Value must be empty.", name);
        }
    }

    /// <summary>
    /// Asserts that the input value must not be <see cref="string.Empty"/>.
    /// </summary>
    /// <param name="value">The string value to be tested.</param>
    /// <param name="name">The name of the tested value.</param>
    /// <exception cref="ArgumentException">Thrown if the value is <see cref="string.Empty"/>.</exception>"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ArgumentIsNotEmpty(string value, [CallerArgumentExpression(nameof(value))] string name = null)
    {
        if (value == string.Empty)
        {
            throw new ArgumentException($"Value must not be empty.", name);
        }
    }

    /// <summary>
    /// Asserts that the input value consists only of white-space characters.
    /// </summary>
    /// <param name="value">The string value to be tested.</param>
    /// <param name="name">The name of the tested value.</param>
    /// <exception cref="ArgumentException">Thrown if the value does not consist only of white-space characters.</exception>"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ArgumentIsWhiteSpace(string value, [CallerArgumentExpression(nameof(value))] string name = null)
    {
        if (!string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException($"Value must consist only of white-space characters.", name);
        }
    }

    /// <summary>
    /// Asserts that the input value does not consist only of white-space characters.
    /// </summary>
    /// <param name="value">The string value to be tested.</param>
    /// <param name="name">The name of the tested value.</param>
    /// <exception cref="ArgumentException">Thrown if the value consists only of white-space characters.</exception>"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ArgumentIsNotWhiteSpace(string value, [CallerArgumentExpression(nameof(value))] string name = null)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException($"Value must not consist only of white-space characters.", name);
        }
    }
}
