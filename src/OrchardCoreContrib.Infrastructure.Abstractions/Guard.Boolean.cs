using System.Runtime.CompilerServices;

namespace OrchardCoreContrib.Infrastructure;

/// <summary>
/// Represents an argument checker.
/// </summary>
public static partial class Guard
{
    /// <summary>
    /// Asserts that the input value must be <see langword="false"/>.
    /// </summary>
    /// <param name="value">The boolean value to be tested.</param>
    /// <param name="name">An optional name of the tested value.</param>
    /// <exception cref="ArgumentException">Thrown if the value is <see langword="true"/>.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ArgumentIsFalse(bool value, [CallerArgumentExpression(nameof(value))] string name = null)
    {
        if (value)
        {
            throw new ArgumentException("Value must be false.", name);
        }
    }

    /// <summary>
    /// Asserts that the input value must be <see langword="true"/>.
    /// </summary>
    /// <param name="value">The boolean value to be tested.</param>
    /// <param name="name">An optional name of the tested value.</param>
    /// <exception cref="ArgumentException">Thrown if the value is <see langword="false"/>.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ArgumentIsTrue(bool value, [CallerArgumentExpression(nameof(value))] string name = null)
    {
        if (value == false)
        {
            throw new ArgumentException("Value must be true.", name);
        }
    }
}
