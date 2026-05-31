using System.Numerics;
using System.Runtime.CompilerServices;

namespace OrchardCoreContrib.Infrastructure;

/// <summary>
/// Represents an argument checker.
/// </summary>
public static partial class Guard
{
    /// <summary>
    /// Asserts that the input value must be zero.
    /// </summary>
    /// <param name="value">The numeric value to be tested.</param>
    /// <param name="name">The name of the tested value. Defaults to <see langword="null" />.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the value is not zero.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ArgumentIsZero<TNumber>(TNumber value, [CallerArgumentExpression(nameof(value))] string name = null) where TNumber : INumberBase<TNumber>
    {
        if (value != TNumber.Zero)
        {
            throw new ArgumentOutOfRangeException(name, "Value must be zero.");
        }
    }

    /// <summary>
    /// Asserts that the input value must be negative.
    /// </summary>
    /// <param name="value">The numeric value to be tested.</param>
    /// <param name="name">The name of the tested value. Defaults to <see langword="null" />.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the value is not negative.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ArgumentIsNegative<TNumber>(TNumber value, [CallerArgumentExpression(nameof(value))] string name = null) where TNumber : INumberBase<TNumber>
    {
        if (!TNumber.IsNegative(value))
        {
            throw new ArgumentOutOfRangeException(name, "Value must be negative.");
        }
    }

    /// <summary>
    /// Asserts that the input value must be positive.
    /// </summary>
    /// <typeparam name="TNumber">The type of the numeric value.</typeparam>
    /// <param name="value">The numeric value to be tested.</param>
    /// <param name="name">The name of the tested value. Defaults to <see langword="null" />.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the value is not positive.</exception>
    public static void ArgumentIsPositive<TNumber>(TNumber value, [CallerArgumentExpression(nameof(value))] string name = null) where TNumber : INumberBase<TNumber>
    {
        if (!TNumber.IsPositive(value))
        {
            throw new ArgumentOutOfRangeException(name, "Value must be positive.");
        }
    }

    /// <summary>
    /// Asserts that the input value must be negative or zero.
    /// </summary>
    /// <param name="value">The numeric value to be tested.</param>
    /// <param name="name">The name of the tested value. Defaults to <see langword="null" />.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the value is not negative or zero.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ArgumentIsNegativeOrZero<TNumber>(TNumber value, [CallerArgumentExpression(nameof(value))] string name = null) where TNumber : INumberBase<TNumber>
    {
        if (!TNumber.IsNegative(value) && value != TNumber.Zero)
        {
            throw new ArgumentOutOfRangeException(name, "Value must be negative or zero.");
        }
    }

    /// <summary>
    /// Asserts that the input value must be equal to another given value.
    /// </summary>
    /// <param name="value">The numeric value to be tested.</param>
    /// <param name="otherValue">The numeric value to compare with.</param>
    /// <param name="name">The name of the tested value. Defaults to <see langword="null" />.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the value is not equal to the other value.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ArgumentIsEqual<TNumber>(TNumber value, TNumber otherValue, [CallerArgumentExpression(nameof(value))] string name = null) where TNumber : IEquatable<TNumber>
    {
        if (!value.Equals(otherValue))
        {
            ArgumentOutOfRangeException.ThrowIfNotEqual(value, otherValue, name);
        }
    }

    /// <summary>
    /// Asserts that the input value must not be equal to another given value.
    /// </summary>
    /// <typeparam name="TNumber">The type of the numeric value.</typeparam>
    /// <param name="value">The numeric value to be tested.</param>
    /// <param name="otherValue">The numeric value to compare with.</param>
    /// <param name="name">The name of the tested value. Defaults to <see langword="null" />.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the value is equal to the other value.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ArgumentIsNotEqual<TNumber>(TNumber value, TNumber otherValue, [CallerArgumentExpression(nameof(value))] string name = null) where TNumber : IEquatable<TNumber>
    {
        if (value.Equals(otherValue))
        {
            ArgumentOutOfRangeException.ThrowIfEqual(value, otherValue, name);
        }
    }

    /// <summary>
    /// Asserts that the input value must be less than another given value.
    /// </summary>
    /// <param name="value">The numeric value to be tested.</param>
    /// <param name="otherValue">The numeric value to compare with.</param>
    /// <param name="name">The name of the tested value. Defaults to <see langword="null" />.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the value is not less than the other value.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ArgumentLessThan<TNumber>(TNumber value, TNumber otherValue, [CallerArgumentExpression(nameof(value))] string name = null) where TNumber : IComparable<TNumber>
    {
        if (value.CompareTo(otherValue) >= 0)
        {
            ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(value, otherValue, name);
        }
    }

    /// <summary>
    /// Asserts that the input value must be less than or equal to another given value.
    /// </summary>
    /// <param name="value">The numeric value to be tested.</param>
    /// <param name="otherValue">The numeric value to compare with.</param>
    /// <param name="name">The name of the tested value. Defaults to <see langword="null" />.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the value is not less than or equal to the other value.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ArgumentIsLessThanOrEqual<TNumber>(TNumber value, TNumber otherValue, [CallerArgumentExpression(nameof(value))] string name = null) where TNumber : IComparable<TNumber>
    {
        if (value.CompareTo(otherValue) > 0)
        {
            ArgumentOutOfRangeException.ThrowIfGreaterThan(value, otherValue, name);
        }
    }

    /// <summary>
    /// Asserts that the input value must be greater than to another given value.
    /// </summary>
    /// <param name="value">The numeric value to be tested.</param>
    /// <param name="otherValue">The numeric value to compare with.</param>
    /// <param name="name">The name of the tested value. Defaults to <see langword="null" />.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the value is not greater than the other value.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ArgumentIsGreaterThan<TNumber>(TNumber value, TNumber otherValue, [CallerArgumentExpression(nameof(value))] string name = null) where TNumber : IComparable<TNumber>
    {
        if (value.CompareTo(otherValue) <= 0)
        {
            ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(value, otherValue, name);
        }
    }

    /// <summary>
    /// Asserts that the input value must be greater than or equal to another given value.
    /// </summary>
    /// <param name="value">The numeric value to be tested.</param>
    /// <param name="otherValue">The numeric value to compare with.</param>
    /// <param name="name">The name of the tested value. Defaults to <see langword="null" />.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the value is not greater than or equal to the other value.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ArgumentIsGreaterThanOrEqual<TNumber>(TNumber value, TNumber otherValue, [CallerArgumentExpression(nameof(value))] string name = null) where TNumber : IComparable<TNumber>
    {
        if (value.CompareTo(otherValue) < 0)
        {
            ArgumentOutOfRangeException.ThrowIfLessThan(value, otherValue, name);
        }
    }
}
