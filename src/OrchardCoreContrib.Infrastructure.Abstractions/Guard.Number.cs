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
    /// <param name="argumentName">The name of the tested value. Defaults to <see langword="null" />.</param>
    public static void ArgumentIsZero<TNumber>(TNumber value, [CallerArgumentExpression(nameof(value))] string name = null) where TNumber : INumberBase<TNumber>
        => ArgumentOutOfRangeException.ThrowIfZero(value, name);

    /// <summary>
    /// Throws <see cref="ArgumentOutOfRangeException"/> if the given value is negative.
    /// </summary>
    /// <param name="value">The numeric value to be tested.</param>
    /// <param name="name">The name of the tested value. Defaults to <see langword="null" />.</param>
    public static void ArgumentIsNegative<TNumber>(TNumber value, [CallerArgumentExpression(nameof(value))] string name = null) where TNumber : INumberBase<TNumber>
        => ArgumentOutOfRangeException.ThrowIfNegative(value, name);

    /// <summary>
    /// Throws <see cref="ArgumentOutOfRangeException"/> if the given value is negative or zero.
    /// </summary>
    /// <param name="value">The numeric value to be tested.</param>
    /// <param name="name">The name of the tested value. Defaults to <see langword="null" />.</param>
    public static void ArgumentIsNegativeOrZero<TNumber>(TNumber value, [CallerArgumentExpression(nameof(value))] string name = null) where TNumber : INumberBase<TNumber>
        => ArgumentOutOfRangeException.ThrowIfNegativeOrZero(value, name);

    /// <summary>
    /// Throws <see cref="ArgumentOutOfRangeException"/> if the given value is equals another given value.
    /// </summary>
    /// <param name="value">The numeric value to be tested.</param>
    /// <param name="otherValue">The numeric value to compare with.</param>
    /// <param name="name">The name of the tested value. Defaults to <see langword="null" />.</param>
    public static void ArgumentIsEqual<TNumber>(TNumber value, TNumber otherValue, [CallerArgumentExpression(nameof(value))] string name = null) where TNumber : IEquatable<TNumber>
        => ArgumentOutOfRangeException.ThrowIfEqual(value, otherValue, name);

    /// <summary>
    /// Throws <see cref="ArgumentOutOfRangeException"/> if the given value is less than another given value.
    /// </summary>
    /// <param name="value">The numeric value to be tested.</param>
    /// <param name="otherValue">The numeric value to compare with.</param>
    /// <param name="name">The name of the tested value. Defaults to <see langword="null" />.</param>
    public static void ArgumentIsLessThan<TNumber>(TNumber value, TNumber otherValue, [CallerArgumentExpression(nameof(value))] string name = null) where TNumber : IComparable<TNumber>
        => ArgumentOutOfRangeException.ThrowIfLessThan(value, otherValue, name);

    /// <summary>
    /// Throws <see cref="ArgumentOutOfRangeException"/> if the given value is less than or equal to another given value.
    /// </summary>
    /// <param name="value">The numeric value to be tested.</param>
    /// <param name="otherValue">The numeric value to compare with.</param>
    /// <param name="name">The name of the tested value. Defaults to <see langword="null" />.</param>
    public static void ArgumentIsLessThanOrEqual<TNumber>(TNumber value, TNumber otherValue, [CallerArgumentExpression(nameof(value))] string name = null) where TNumber : IComparable<TNumber>
        => ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(value, otherValue, name);

    /// <summary>
    /// Throws <see cref="ArgumentOutOfRangeException"/> if the given value is greater than another given value.
    /// </summary>
    /// <param name="value">The numeric value to be tested.</param>
    /// <param name="otherValue">The numeric value to compare with.</param>
    /// <param name="name">The name of the tested value. Defaults to <see langword="null" />.</param>
    public static void ArgumentIsGreaterThan<TNumber>(TNumber value, TNumber otherValue, [CallerArgumentExpression(nameof(value))] string name = null) where TNumber : IComparable<TNumber>
        => ArgumentOutOfRangeException.ThrowIfGreaterThan(value, otherValue, name);

    /// <summary>
    /// Throws <see cref="ArgumentOutOfRangeException"/> if the given value is greater than or equals another given value.
    /// </summary>
    /// <param name="value">The numeric value to be tested.</param>
    /// <param name="otherValue">The numeric value to compare with.</param>
    /// <param name="name">The name of the tested value. Defaults to <see langword="null" />.</param>
    public static void ArgumentIsGreaterThanOrEqual<TNumber>(TNumber value, TNumber otherValue, [CallerArgumentExpression(nameof(value))] string name = null) where TNumber : IComparable<TNumber>
        => ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(value, otherValue, name);
}
