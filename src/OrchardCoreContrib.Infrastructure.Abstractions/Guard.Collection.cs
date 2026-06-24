using System.Runtime.CompilerServices;

namespace OrchardCoreContrib.Infrastructure;

/// <summary>
/// Represents an argument checker.
/// </summary>
public static partial class Guard
{
    /// <summary>
    /// Asserts that the input value must be null.
    /// </summary>
    /// <param name="value">The collection to be tested.</param>
    /// <param name="name">The name of the tested collection.</param>
    /// <exception cref="ArgumentNullException">Thrown when the collection is not <see langword="null" />.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ArgumentIsNull<TType>(IEnumerable<TType> value, [CallerArgumentExpression(nameof(value))] string name = null)
    {
        if (value is not null)
        {
            throw new ArgumentNullException(name, "Value must be null.");
        }
    }

    /// <summary>
    /// Asserts that the input value must not be null.
    /// </summary>
    /// <param name="value">The collection to be tested.</param>
    /// <param name="name">The name of the tested collection.</param>
    /// <exception cref="ArgumentNullException">Thrown when the collection is <see langword="null" />.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ArgumentNotNull<TType>(IEnumerable<TType> value, [CallerArgumentExpression(nameof(value))] string name = null)
    {
        if (value is null)
        {
            throw new ArgumentNullException(name, "Value must not be null.");
        }
    }

    /// <summary>
    /// Asserts that the input value must be empty.
    /// </summary>
    /// <param name="value">The collection to be tested.</param>
    /// <param name="name">The name of the tested collection.</param>
    /// <exception cref="ArgumentException">Thrown when the collection is not empty.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ArgumentIsEmpty<TType>(IEnumerable<TType> value, [CallerArgumentExpression(nameof(value))] string name = null)
    {
        Guard.ArgumentNotNull(value);

        if (value.Any())
        {
            throw new ArgumentException("Collection must be empty.", name);
        }
    }

    /// <summary>
    /// Asserts that the input value must not be empty.
    /// </summary>
    /// <param name="value">The collection to be tested.</param>
    /// <param name="name">The name of the tested collection.</param>
    /// <exception cref="ArgumentException">Thrown when the collection is empty.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ArgumentIsNotEmpty<TType>(IEnumerable<TType> value, [CallerArgumentExpression(nameof(value))] string name = null)
    {
        Guard.ArgumentNotNull(value);

        if (!value.Any())
        {
            throw new ArgumentException("Collection must not be empty.", name);
        }
    }

    /// <summary>
    /// Asserts that the input value must not be null or empty.
    /// </summary>
    /// <param name="value">The collection to be tested.</param>
    /// <param name="name">The name of the tested collection.</param>
    /// <exception cref="ArgumentNullOrEmptyException">Thrown when the collection is <see langword="null" /> or empty.</exception>
    [Obsolete("Use the generic version of this method instead to avoid unnecessary boxing.", true)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ArgumentNotNullOrEmpty(IEnumerable<object> value, [CallerArgumentExpression(nameof(value))] string name = null)
        => ArgumentNotNullOrEmpty<object>(value, name);

    /// <summary>
    /// Asserts that the input value must not be null or empty.
    /// </summary>
    /// <param name="value">The collection to be tested.</param>
    /// <param name="name">The name of the tested collection.</param>
    /// <exception cref="ArgumentNullOrEmptyException">Thrown when the collection is <see langword="null" /> or empty.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ArgumentNotNullOrEmpty<TType>(IEnumerable<TType> value, [CallerArgumentExpression(nameof(value))] string name = null)
    {
        Guard.ArgumentNotNull(value);

        if (!value.Any())
        {
            throw new ArgumentException("Collection cannot be empty.", name);
        }
    }

    /// <summary>
    /// Asserts that the collection must not contain null elements.
    /// </summary>
    /// <param name="value">The collection to be tested.</param>
    /// <param name="name">The name of the tested collection.</param>
    /// <exception cref="ArgumentException">Thrown when the collection contains <see langword="null" /> elements.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ArgumentDoesNotContainNullElements<TType>(IEnumerable<TType> value, [CallerArgumentExpression(nameof(value))] string name = null)
    {
        Guard.ArgumentNotNull(value);

        if (value.Any(item => item is null))
        {
            throw new ArgumentException("Collection contains null elements.", name);
        }
    }

    /// <summary>
    /// Asserts that the collection must not contain duplicate elements.
    /// </summary>
    /// <param name="value">The collection to be tested.</param>
    /// <param name="name">The name of the tested collection.</param>
    /// <exception cref="ArgumentException">Thrown when the collection contains duplicate elements.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ArgumentContainsDuplicateElements<TType>(IEnumerable<TType> value, [CallerArgumentExpression(nameof(value))] string name = null)
    {
        Guard.ArgumentNotNull(value);

        var items = new HashSet<TType>();
        foreach (var item in value)
        {
            if (!items.Add(item))
            {
                throw new ArgumentException("Collection contains duplicate elements.", name);
            }
        }
    }
}
