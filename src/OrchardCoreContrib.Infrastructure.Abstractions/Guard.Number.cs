using System.Numerics;

namespace OrchardCoreContrib.Infrastructure;

/// <summary>
/// Represents an argument checker for <see cref="INumberBase"/>.
/// </summary>
public static partial class Guard
{
    /// <summary>
    /// Throws <see cref="ArgumentNullOrEmptyException"/> if the given value is zero.
    /// </summary>
    /// <param name="argumentValue">The numeric value to be tested.</param>
    /// <param name="argumentName">The name of the tested value. Defaults to <see langword="null" />.</param>
    public static void ArgumentIsZero<TNumber>(TNumber argumentValue, string argumentName = null) where TNumber : INumberBase<TNumber>
        => ArgumentOutOfRangeException.ThrowIfZero(argumentValue, argumentName);

    /// <summary>
    /// Throws <see cref="ArgumentNullOrEmptyException"/> if the given value is negative.
    /// </summary>
    /// <param name="argumentValue">The numeric value to be tested.</param>
    /// <param name="argumentName">The name of the tested value. Defaults to <see langword="null" />.</param>
    public static void ArgumentIsNegative<TNumber>(TNumber argumentValue, string argumentName = null) where TNumber : INumberBase<TNumber>
        => ArgumentOutOfRangeException.ThrowIfNegative(argumentValue, argumentName);

    /// <summary>
    /// Throws <see cref="ArgumentNullOrEmptyException"/> if the given value is negative or zero.
    /// </summary>
    /// <param name="argumentValue">The numeric value to be tested.</param>
    /// <param name="argumentName">The name of the tested value. Defaults to <see langword="null" />.</param>
    public static void ArgumentIsNegativeOrZero<TNumber>(TNumber argumentValue, string argumentName = null) where TNumber : INumberBase<TNumber>
        => ArgumentOutOfRangeException.ThrowIfNegativeOrZero(argumentValue, argumentName);

    /// <summary>
    /// Throws <see cref="ArgumentNullOrEmptyException"/> if the given value is equals another given value.
    /// </summary>
    /// <param name="argumentValue">The numeric value to be tested.</param>
    /// <param name="otherValue">The numeric value to compare with.</param>
    /// <param name="argumentName">The name of the tested value. Defaults to <see langword="null" />.</param>
    public static void ArgumentIsEqual<TNumber>(TNumber argumentValue, TNumber otherValue, string argumentName = null) where TNumber : IEquatable<TNumber>
        => ArgumentOutOfRangeException.ThrowIfEqual(argumentValue, otherValue, argumentName);

    /// <summary>
    /// Throws <see cref="ArgumentNullOrEmptyException"/> if the given value is less than another given value.
    /// </summary>
    /// <param name="argumentValue">The numeric value to be tested.</param>
    /// <param name="otherValue">The numeric value to compare with.</param>
    /// <param name="argumentName">The name of the tested value. Defaults to <see langword="null" />.</param>
    public static void ArgumentIsLessThan<TNumber>(TNumber argumentValue, TNumber otherValue, string argumentName = null) where TNumber : IComparable<TNumber>
        => ArgumentOutOfRangeException.ThrowIfLessThan(argumentValue, otherValue, argumentName);

    /// <summary>
    /// Throws <see cref="ArgumentOutOfRangeException"/> if the given value is less than or equal to another given value.
    /// </summary>
    /// <param name="argumentValue">The numeric value to be tested.</param>
    /// <param name="otherValue">The numeric value to compare with.</param>
    /// <param name="argumentName">The name of the tested value. Defaults to <see langword="null" />.</param>
    public static void ArgumentIsLessThanOrEqual<TNumber>(TNumber argumentValue, TNumber otherValue, string argumentName = null) where TNumber : IComparable<TNumber>
        => ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(argumentValue, otherValue, argumentName);

    /// <summary>
    /// Throws <see cref="ArgumentNullOrEmptyException"/> if the given value is greater than another given value.
    /// </summary>
    /// <param name="argumentValue">The numeric value to be tested.</param>
    /// <param name="otherValue">The numeric value to compare with.</param>
    /// <param name="argumentName">The name of the tested value. Defaults to <see langword="null" />.</param>
    public static void ArgumentIsGreaterThan<TNumber>(TNumber argumentValue, TNumber otherValue, string argumentName = null) where TNumber : IComparable<TNumber>
        => ArgumentOutOfRangeException.ThrowIfGreaterThan(argumentValue, otherValue, argumentName);

    /// <summary>
    /// Throws <see cref="ArgumentNullOrEmptyException"/> if the given value is greater than or equals another given value.
    /// </summary>
    /// <param name="argumentValue">The numeric value to be tested.</param>
    /// <param name="otherValue">The numeric value to compare with.</param>
    /// <param name="argumentName">The name of the tested value. Defaults to <see langword="null" />.</param>
    public static void ArgumentIsGreaterThanOrEqual<TNumber>(TNumber argumentValue, TNumber otherValue, string argumentName = null) where TNumber : IComparable<TNumber>
        => ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(argumentValue, otherValue, argumentName);
}
