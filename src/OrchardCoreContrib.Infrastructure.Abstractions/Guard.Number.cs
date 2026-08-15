using System.Numerics;
using System.Runtime.CompilerServices;

namespace OrchardCoreContrib.Infrastructure;

/// <summary>
/// Represents an argument checker.
/// </summary>
public static partial class Guard
{
    /// <summary>
    /// Ensures that the input value is not zero.
    /// </summary>
    /// <param name="value">The numeric value to be tested.</param>
    /// <param name="name">The name of the tested value. Defaults to <see langword="null" />.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the value is zero.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ArgumentNotZero<TNumber>(TNumber value, [CallerArgumentExpression(nameof(value))] string name = null) where TNumber : INumberBase<TNumber>
        => ArgumentOutOfRangeException.ThrowIfZero(value, name);

    /// <summary>
    /// Ensures that the input value is not negative.
    /// </summary>
    /// <param name="value">The numeric value to be tested.</param>
    /// <param name="name">The name of the tested value. Defaults to <see langword="null" />.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the value is negative.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ArgumentNotNegative<TNumber>(TNumber value, [CallerArgumentExpression(nameof(value))] string name = null) where TNumber : INumberBase<TNumber>
        => ArgumentOutOfRangeException.ThrowIfNegative(value, name);

    /// <summary>
    /// Ensures that the input value is not negative or zero.
    /// </summary>
    /// <param name="value">The numeric value to be tested.</param>
    /// <param name="name">The name of the tested value. Defaults to <see langword="null" />.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the value is negative or zero.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ArgumentNotNegativeOrZero<TNumber>(TNumber value, [CallerArgumentExpression(nameof(value))] string name = null) where TNumber : INumberBase<TNumber>
        => ArgumentOutOfRangeException.ThrowIfNegativeOrZero(value, name);

    /// <summary>
    /// Ensures that the input value is equal to another given value.
    /// </summary>
    /// <typeparam name="TNumber">The type of the numeric value.</typeparam>
    /// <param name="value">The numeric value to be tested.</param>
    /// <param name="otherValue">The numeric value to compare with.</param>
    /// <param name="name">The name of the tested value. Defaults to <see langword="null" />.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the value is not equal to the other value.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ArgumentEquals<TNumber>(TNumber value, TNumber otherValue, [CallerArgumentExpression(nameof(value))] string name = null) where TNumber : INumberBase<TNumber>
        => ArgumentOutOfRangeException.ThrowIfNotEqual(value, otherValue, name);

    /// <summary>
    /// Ensures that the input value is not equal to another given value.
    /// </summary>
    /// <typeparam name="TNumber">The type of the numeric value.</typeparam>
    /// <param name="value">The numeric value to be tested.</param>
    /// <param name="otherValue">The numeric value to compare with.</param>
    /// <param name="name">The name of the tested value. Defaults to <see langword="null" />.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the value is equal to the other value.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ArgumentNotEquals<TNumber>(TNumber value, TNumber otherValue, [CallerArgumentExpression(nameof(value))] string name = null) where TNumber : INumberBase<TNumber>
        => ArgumentOutOfRangeException.ThrowIfEqual(value, otherValue, name);

    /// <summary>
    /// Ensures that the input value is less than another given value.
    /// </summary>
    /// <param name="value">The numeric value to be tested.</param>
    /// <param name="otherValue">The numeric value to compare with.</param>
    /// <param name="name">The name of the tested value. Defaults to <see langword="null" />.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the value is not less than the other value.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ArgumentLessThan<TNumber>(TNumber value, TNumber otherValue, [CallerArgumentExpression(nameof(value))] string name = null) where TNumber : INumberBase<TNumber>, IComparable<TNumber>
        => ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(value, otherValue, name);

    /// <summary>
    /// Ensures that the input value is less than or equal to another given value.
    /// </summary>
    /// <param name="value">The numeric value to be tested.</param>
    /// <param name="otherValue">The numeric value to compare with.</param>
    /// <param name="name">The name of the tested value. Defaults to <see langword="null" />.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the value is not less than or equal to the other value.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ArgumentLessThanOrEqual<TNumber>(TNumber value, TNumber otherValue, [CallerArgumentExpression(nameof(value))] string name = null) where TNumber : INumberBase<TNumber>, IComparable<TNumber>
        => ArgumentOutOfRangeException.ThrowIfGreaterThan(value, otherValue, name);

    /// <summary>
    /// Ensures that the input value is greater than another given value.
    /// </summary>
    /// <param name="value">The numeric value to be tested.</param>
    /// <param name="otherValue">The numeric value to compare with.</param>
    /// <param name="name">The name of the tested value. Defaults to <see langword="null" />.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the value is not greater than the other value.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ArgumentGreaterThan<TNumber>(TNumber value, TNumber otherValue, [CallerArgumentExpression(nameof(value))] string name = null) where TNumber : INumberBase<TNumber>, IComparable<TNumber>
        => ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(value, otherValue, name);

    /// <summary>
    /// Ensures that the input value is greater than or equal to another given value.
    /// </summary>
    /// <param name="value">The numeric value to be tested.</param>
    /// <param name="otherValue">The numeric value to compare with.</param>
    /// <param name="name">The name of the tested value. Defaults to <see langword="null" />.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the value is not greater than or equal to the other value.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ArgumentGreaterThanOrEqual<TNumber>(TNumber value, TNumber otherValue, [CallerArgumentExpression(nameof(value))] string name = null) where TNumber : INumberBase<TNumber>, IComparable<TNumber>
        => ArgumentOutOfRangeException.ThrowIfLessThan(value, otherValue, name);

    /// <summary>
    /// Ensures that the input value is within the specified range (inclusive).
    /// </summary>
    /// <typeparam name="TNumber">The numeric type of the values.</typeparam>
    /// <param name="minValue">The minimum value of the range.</param>
    /// <param name="maxValue">The maximum value of the range.</param>
    /// <param name="value">The numeric value to be tested.</param>
    /// <param name="name">The name of the tested value. Defaults to <see langword="null" />.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the value is not within the specified range.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ArgumentInRange<TNumber>(TNumber minValue, TNumber maxValue, TNumber value, [CallerArgumentExpression(nameof(value))] string name = null) where TNumber : IComparable<TNumber>
    {
        if (value.CompareTo(minValue) < 0 || value.CompareTo(maxValue) > 0)
        {
            throw new ArgumentOutOfRangeException(name, value, $"{name} must be between {minValue} and {maxValue} (inclusive).");
        }
    }
}
