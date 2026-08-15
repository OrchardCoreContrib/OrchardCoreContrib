using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace OrchardCoreContrib.Infrastructure;

/// <summary>
/// Represents an argument checker.
/// </summary>
[DebuggerStepThrough]
public static partial class Guard
{
    /// <summary>
    /// Ensures that the input value is <see langword="null"/>.
    /// </summary>
    /// <param name="value">The value to be tested.</param>
    /// <param name="name">The name of the tested value.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ArgumentNull(object value, [CallerArgumentExpression(nameof(value))] string name = null)
    {
        if (value is not null)
        {
            throw new ArgumentException(name, "The value must be null.");
        }
    }

    /// <summary>
    /// Asserts that the input value is not <see langword="null"/>.
    /// </summary>
    /// <param name="value">The value to be tested.</param>
    /// <param name="name">The name of the tested value.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ArgumentNotNull(object value, [CallerArgumentExpression(nameof(value))] string name = null)
        => ArgumentNullException.ThrowIfNull(value, name);

    /// <summary>
    /// Ensures that the input value is of the specified type.
    /// </summary>
    /// <typeparam name="TType">The type to check against.</typeparam>
    /// <param name="value">The value to be tested.</param>
    /// <param name="name">The name of the tested value.</param>
    /// <exception cref="ArgumentException">Thrown when the value is not of the specified type.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ArgumentOfType<TType>(object value, [CallerArgumentExpression(nameof(value))] string name = null)
    {
        Guard.ArgumentNotNull(value, name);

        if (value is not TType)
        {
            throw new ArgumentException($"The value must be assignable to type {typeof(TType).Name}.", name);
        }
    }

    /// <summary>
    /// Ensures that the input value is not of the specified type.
    /// </summary>
    /// <typeparam name="TType">The type to check against.</typeparam>
    /// <param name="value">The value to be tested.</param>
    /// <param name="name">The name of the tested value.</param>
    /// <exception cref="ArgumentException">Thrown when the value is of the specified type.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ArgumentNotOfType<TType>(object value, [CallerArgumentExpression(nameof(value))] string name = null)
    {
        Guard.ArgumentNotNull(value, name);

        if (value is TType)
        {
            throw new ArgumentException($"The value must not be of type {typeof(TType).Name}.", name);
        }
    }

    /// <summary>
    /// Ensures that the input values are equal.
    /// </summary>
    /// <param name="value">The first value to be tested.</param>
    /// <param name="otherValue">The second value to be tested.</param>
    /// <param name="name">The name of the tested value.</param>
    /// <exception cref="ArgumentException">Thrown when the values are not equal.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ArgumentEquals(object value, object otherValue, [CallerArgumentExpression(nameof(value))] string name = null)
    {
        Guard.ArgumentNotNull(value, name);
        Guard.ArgumentNotNull(otherValue, name);

        if (!value.Equals(otherValue))
        {
            throw new ArgumentException($"The value must be equal to {otherValue}.", name);
        }
    }

    /// <summary>
    /// Ensures that the input values are not equal.
    /// </summary>
    /// <param name="value">The first value to be tested.</param>
    /// <param name="otherValue">The second value to be tested.</param>
    /// <param name="name">The name of the tested value.</param>
    /// <exception cref="ArgumentException">Thrown when the values are equal.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ArgumentNotEquals(object value, object otherValue, [CallerArgumentExpression(nameof(value))] string name = null)
    {
        Guard.ArgumentNotNull(value, name);
        Guard.ArgumentNotNull(otherValue, name);

        if (value.Equals(otherValue))
        {
            throw new ArgumentException($"The value must not be equal to {otherValue}.", name);
        }
    }

    /// <summary>
    /// Ensures that the input value is assignable to the specified type.
    /// </summary>
    /// <typeparam name="TType">The type to check against.</typeparam>
    /// <param name="value">The value to be tested.</param>
    /// <param name="name">The name of the tested value.</param>
    /// <exception cref="ArgumentException">Thrown when the value is not assignable to the specified type.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ArgumentAssignableToType<TType>(object value, [CallerArgumentExpression(nameof(value))] string name = null)
    {
        Guard.ArgumentNotNull(value, name);

        var targetType = typeof(TType);
        if (!targetType.IsAssignableFrom(value.GetType()))
        {
            throw new ArgumentException($"The value must be assignable to type {targetType.Name}.", name);
        }
    }

    /// <summary>
    /// Ensures that the input value is not assignable to the specified type.
    /// </summary>
    /// <typeparam name="TType">The type to check against.</typeparam>
    /// <param name="value">The value to be tested.</param>
    /// <param name="name">The name of the tested value.</param>
    /// <exception cref="ArgumentException">Thrown when the value is assignable to the specified type.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ArgumentNotAssignableToType<TType>(object value, [CallerArgumentExpression(nameof(value))] string name = null)
    {
        Guard.ArgumentNotNull(value, name);

        var targetType = typeof(TType);
        if (targetType.IsAssignableFrom(value.GetType()))
        {
            throw new ArgumentException($"The value must not be assignable to type {targetType.Name}.", name);
        }
    }
}
