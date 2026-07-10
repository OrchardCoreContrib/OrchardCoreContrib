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
    /// Throws <see cref="ArgumentNullException"/> if the given value is <see langword="null" />.
    /// </summary>
    /// <param name="value">The value to be tested.</param>
    /// <param name="name">The name of the tested value.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ArgumentNotNull(object value, [CallerArgumentExpression(nameof(value))] string name = null)
    {
        if (value is null)
        {
            ArgumentNullException.ThrowIfNull(value, name);
        }
    }

    /// <summary>
    /// Asserts that the input value is of the specified type.
    /// </summary>
    /// <typeparam name="TType">The type to check against.</typeparam>
    /// <param name="value">The value to be tested.</param>
    /// <param name="name">The name of the tested value.</param>
    /// <exception cref="ArgumentException">Thrown when the value is not of the specified type.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ArgumentIsOfType<TType>(object value, [CallerArgumentExpression(nameof(value))] string name = null)
    {
        if (value.GetType() != typeof(TType))
        {
            throw new ArgumentException($"The value must be of type {typeof(TType).Name}.", name);
        }
    }

    /// <summary>
    /// Asserts that the input value is not of the specified type.
    /// </summary>
    /// <typeparam name="TType">The type to check against.</typeparam>
    /// <param name="value">The value to be tested.</param>
    /// <param name="name">The name of the tested value.</param>
    /// <exception cref="ArgumentException">Thrown when the value is of the specified type.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ArgumentIsNotOfType<TType>(object value, [CallerArgumentExpression(nameof(value))] string name = null)
    {
        if (value.GetType() == typeof(TType))
        {
            throw new ArgumentException($"The value must not be of type {typeof(TType).Name}.", name);
        }
    }

    /// <summary>
    /// Asserts that the input value is of the specified type.
    /// </summary>
    /// <param name="value">The value to be tested.</param>
    /// <param name="type">The type to check against.</param>
    /// <param name="name">The name of the tested value.</param>
    /// <exception cref="ArgumentException">Thrown when the value is not of the specified type.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ArgumentIsOfType(object value, Type type, [CallerArgumentExpression(nameof(value))] string name = null)
    {
        if (value.GetType() != type)
        {
            throw new ArgumentException($"The value must be of type {type.Name}.", name);
        }
    }

    /// <summary>
    /// Asserts that the input value is not of the specified type.
    /// </summary>
    /// <param name="value">The value to be tested.</param>
    /// <param name="type">The type to check against.</param>
    /// <param name="name">The name of the tested value.</param>
    /// <exception cref="ArgumentException">Thrown when the value is of the specified type.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ArgumentIsNotOfType(object value, Type type, [CallerArgumentExpression(nameof(value))] string name = null)
    {
        if (value.GetType() == type)
        {
            throw new ArgumentException($"The value must not be of type {type.Name}.", name);
        }
    }

    /// <summary>
    /// Asserts that the input value is assignable to the specified type.
    /// </summary>
    /// <typeparam name="TType">The type to check against.</typeparam>
    /// <param name="value">The value to be tested.</param>
    /// <param name="name">The name of the tested value.</param>
    /// <exception cref="ArgumentException">Thrown when the value is not assignable to the specified type.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ArgumentIsAssignableToType<TType>(object value, [CallerArgumentExpression(nameof(value))] string name = null)
    {
        if (value is not TType)
        {
            throw new ArgumentException($"The value must be assignable to type {typeof(TType).Name}.", name);
        }
    }

    /// <summary>
    /// Asserts that the input value is not assignable to the specified type.
    /// </summary>
    /// <typeparam name="TType">The type to check against.</typeparam>
    /// <param name="value">The value to be tested.</param>
    /// <param name="name">The name of the tested value.</param>
    /// <exception cref="ArgumentException">Thrown when the value is assignable to the specified type.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ArgumentIsNotAssignableToType<TType>(object value, [CallerArgumentExpression(nameof(value))] string name = null)
    {
        if (value is TType)
        {
            throw new ArgumentException($"The value must not be assignable to type {typeof(TType).Name}.", name);
        }
    }

    /// <summary>
    /// Asserts that the input value is assignable to the specified type.
    /// </summary>
    /// <param name="value">The value to be tested.</param>
    /// <param name="type">The type to check against.</param>
    /// <param name="name">The name of the tested value.</param>
    /// <exception cref="ArgumentException">Thrown when the value is not assignable to the specified type.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ArgumentIsAssignableToType(object value, Type type, [CallerArgumentExpression(nameof(value))] string name = null)
    {
        if (!type.IsInstanceOfType(value))
        {
            throw new ArgumentException($"The value must be assignable to type {type.Name}.", name);
        }
    }

    /// <summary>
    /// Asserts that the input value is not assignable to the specified type.
    /// </summary>
    /// <param name="value">The value to be tested.</param>
    /// <param name="type">The type to check against.</param>
    /// <param name="name">The name of the tested value.</param>
    /// <exception cref="ArgumentException">Thrown when the value is assignable to the specified type.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ArgumentIsNotAssignableToType(object value, Type type, [CallerArgumentExpression(nameof(value))] string name = null)
    {
        if (type.IsInstanceOfType(value))
        {
            throw new ArgumentException($"The value must not be assignable to type {type.Name}.", name);
        }
    }
}
