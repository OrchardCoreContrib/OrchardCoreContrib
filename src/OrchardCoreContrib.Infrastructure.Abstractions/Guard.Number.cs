using System.Numerics;
using System.Runtime.CompilerServices;

namespace OrchardCoreContrib.Infrastructure;

/// <summary>
/// Represents an argument checker for <see cref="INumberBase"/>.
/// </summary>
public static partial class Guard
{
    /// <summary>
    /// Throws <see cref="ArgumentOutOfRangeException"/> if the given value is zero.
    /// </summary>
    /// <param name="value">The numeric value to be tested.</param>
    /// <param name="name">The name of the tested value. Defaults to <see langword="null" />.</param>
    public static void ArgumentNotZero<TNumber>(TNumber value, [CallerArgumentExpression(nameof(value))] string name = null) where TNumber : INumberBase<TNumber>
        => ArgumentOutOfRangeException.ThrowIfZero(value, name);

    /// <summary>
    /// Throws <see cref="ArgumentOutOfRangeException"/> if the given value is negative.
    /// </summary>
    /// <param name="value">The numeric value to be tested.</param>
    /// <param name="name">The name of the tested value. Defaults to <see langword="null" />.</param>
    public static void ArgumentNotNegative<TNumber>(TNumber value, [CallerArgumentExpression(nameof(value))] string name = null) where TNumber : INumberBase<TNumber>
        => ArgumentOutOfRangeException.ThrowIfNegative(value, name);

    /// <summary>
    /// Throws <see cref="ArgumentOutOfRangeException"/> if the given value is negative or zero.
    /// </summary>
    /// <param name="value">The numeric value to be tested.</param>
    /// <param name="name">The name of the tested value. Defaults to <see langword="null" />.</param>
    public static void ArgumentPositive<TNumber>(TNumber value, [CallerArgumentExpression(nameof(value))] string name = null) where TNumber : INumberBase<TNumber>
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(value, name);
    }

    /// <summary>
    /// Throws <see cref="ArgumentOutOfRangeException"/> if the given value is equals another given value.
    /// </summary>
    /// <param name="value">The numeric value to be tested.</param>
    /// <param name="otherValue">The numeric value to compare with.</param>
    /// <param name="name">The name of the tested value. Defaults to <see langword="null" />.</param>
    public static void ArgumentNotEqual<TNumber>(TNumber value, TNumber otherValue, [CallerArgumentExpression(nameof(value))] string name = null) where TNumber : IEquatable<TNumber>
        => ArgumentOutOfRangeException.ThrowIfEqual(value, otherValue, name);

    /// <summary>
    /// Throws <see cref="ArgumentOutOfRangeException"/> if the given value is less than another given value.
    /// </summary>
    /// <param name="value">The numeric value to be tested.</param>
    /// <param name="otherValue">The numeric value to compare with.</param>
    /// <param name="name">The name of the tested value. Defaults to <see langword="null" />.</param>
    public static void ArgumentAtLeast<TNumber>(TNumber value, TNumber otherValue, [CallerArgumentExpression(nameof(value))] string name = null) where TNumber : IComparable<TNumber>
        => ArgumentOutOfRangeException.ThrowIfLessThan(value, otherValue, name);

    /// <summary>
    /// Throws <see cref="ArgumentOutOfRangeException"/> if the given value is less than or equal to another given value.
    /// </summary>
    /// <param name="value">The numeric value to be tested.</param>
    /// <param name="otherValue">The numeric value to compare with.</param>
    /// <param name="name">The name of the tested value. Defaults to <see langword="null" />.</param>
    public static void ArgumentGreaterThan<TNumber>(TNumber value, TNumber otherValue, [CallerArgumentExpression(nameof(value))] string name = null) where TNumber : IComparable<TNumber>
        => ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(value, otherValue, name);

    /// <summary>
    /// Throws <see cref="ArgumentOutOfRangeException"/> if the given value is greater than another given value.
    /// </summary>
    /// <param name="value">The numeric value to be tested.</param>
    /// <param name="otherValue">The numeric value to compare with.</param>
    /// <param name="name">The name of the tested value. Defaults to <see langword="null" />.</param>
    public static void ArgumentAtMost<TNumber>(TNumber value, TNumber otherValue, [CallerArgumentExpression(nameof(value))] string name = null) where TNumber : IComparable<TNumber>
        => ArgumentOutOfRangeException.ThrowIfGreaterThan(value, otherValue, name);

    /// <summary>
    /// Throws <see cref="ArgumentOutOfRangeException"/> if the given value is greater than or equals another given value.
    /// </summary>
    /// <param name="value">The numeric value to be tested.</param>
    /// <param name="otherValue">The numeric value to compare with.</param>
    /// <param name="name">The name of the tested value. Defaults to <see langword="null" />.</param>
    public static void ArgumentLessThan<TNumber>(TNumber value, TNumber otherValue, [CallerArgumentExpression(nameof(value))] string name = null) where TNumber : IComparable<TNumber>
        => ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(value, otherValue, name);
}
