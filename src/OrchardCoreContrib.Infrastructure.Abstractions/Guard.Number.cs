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
    [Obsolete("Use ArgumentNotZero instead.")]
    public static void ArgumentIsZero<TNumber>(TNumber value, [CallerArgumentExpression(nameof(value))] string name = null) where TNumber : INumberBase<TNumber>
        => Guard.ArgumentNotZero(value, name);

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
    [Obsolete("Use ArgumentNotNegative instead.")]
    public static void ArgumentIsNegative<TNumber>(TNumber value, [CallerArgumentExpression(nameof(value))] string name = null) where TNumber : INumberBase<TNumber>
        => Guard.ArgumentNotNegative(value, name);

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
    [Obsolete("Use ArgumentIsPositive instead.")]
    public static void ArgumentIsNegativeOrZero<TNumber>(TNumber value, [CallerArgumentExpression(nameof(value))] string name = null) where TNumber : INumberBase<TNumber>
        => Guard.ArgumentIsPositive(value, name);

    /// <summary>
    /// Throws <see cref="ArgumentOutOfRangeException"/> if the given value is negative or zero.
    /// </summary>
    /// <param name="value">The numeric value to be tested.</param>
    /// <param name="name">The name of the tested value. Defaults to <see langword="null" />.</param>
    public static void ArgumentIsPositive<TNumber>(TNumber value, [CallerArgumentExpression(nameof(value))] string name = null) where TNumber : INumberBase<TNumber>
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(value, name);
    }

    /// <summary>
    /// Throws <see cref="ArgumentOutOfRangeException"/> if the given value is equals another given value.
    /// </summary>
    /// <param name="value">The numeric value to be tested.</param>
    /// <param name="otherValue">The numeric value to compare with.</param>
    /// <param name="name">The name of the tested value. Defaults to <see langword="null" />.</param>
    [Obsolete("Use ArgumentNotEqual instead.")]
    public static void ArgumentIsEqual<TNumber>(TNumber value, TNumber otherValue, [CallerArgumentExpression(nameof(value))] string name = null) where TNumber : IEquatable<TNumber>
        => Guard.ArgumentNotEqual(value, otherValue, name);

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
    [Obsolete("Use ArgumentIsGreaterThan instead.")]
    public static void ArgumentIsLessThanOrEqual<TNumber>(TNumber value, TNumber otherValue, [CallerArgumentExpression(nameof(value))] string name = null) where TNumber : IComparable<TNumber>
        => Guard.ArgumentIsGreaterThan(value, otherValue, name);

    /// <summary>
    /// Throws <see cref="ArgumentOutOfRangeException"/> if the given value is less than or equal to another given value.
    /// </summary>
    /// <param name="value">The numeric value to be tested.</param>
    /// <param name="otherValue">The numeric value to compare with.</param>
    /// <param name="name">The name of the tested value. Defaults to <see langword="null" />.</param>
    public static void ArgumentIsGreaterThan<TNumber>(TNumber value, TNumber otherValue, [CallerArgumentExpression(nameof(value))] string name = null) where TNumber : IComparable<TNumber>
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
    [Obsolete("Use ArgumentIsLessThan instead.")]
    public static void ArgumentIsGreaterThanOrEqual<TNumber>(TNumber value, TNumber otherValue, [CallerArgumentExpression(nameof(value))] string name = null) where TNumber : IComparable<TNumber>
        => Guard.ArgumentIsLessThan(value, otherValue, name);

    /// <summary>
    /// Throws <see cref="ArgumentOutOfRangeException"/> if the given value is greater than or equals another given value.
    /// </summary>
    /// <param name="value">The numeric value to be tested.</param>
    /// <param name="otherValue">The numeric value to compare with.</param>
    /// <param name="name">The name of the tested value. Defaults to <see langword="null" />.</param>
    public static void ArgumentIsLessThan<TNumber>(TNumber value, TNumber otherValue, [CallerArgumentExpression(nameof(value))] string name = null) where TNumber : IComparable<TNumber>
        => ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(value, otherValue, name);
}
