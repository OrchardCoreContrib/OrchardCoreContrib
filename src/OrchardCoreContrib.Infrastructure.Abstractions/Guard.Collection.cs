using System.Runtime.CompilerServices;

namespace OrchardCoreContrib.Infrastructure;

/// <summary>
/// Represents an argument checker.
/// </summary>
public static partial class Guard
{
    /// <summary>
    /// Ensures that the input collection must not be null.
    /// </summary>
    /// <param name="collection">The collection to be tested.</param>
    /// <param name="name">The name of the tested collection.</param>
    /// <exception cref="ArgumentNullException">Thrown when the collection is <see langword="null" />.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ArgumentNotNull<TType>(IEnumerable<TType> collection, [CallerArgumentExpression(nameof(collection))] string name = null)
    {
        if (collection is null)
        {
            throw new ArgumentNullException(name, "Collection must not be null.");
        }
    }

    /// <summary>
    /// Ensures that the input collection must not be empty.
    /// </summary>
    /// <param name="collection">The collection to be tested.</param>
    /// <param name="name">The name of the tested collection.</param>
    /// <exception cref="ArgumentException">Thrown when the collection is empty.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ArgumentNotEmpty<TType>(IEnumerable<TType> collection, [CallerArgumentExpression(nameof(collection))] string name = null)
    {
        Guard.ArgumentNotNull(collection, name);

        if (!collection.Any())
        {
            throw new ArgumentException("Collection must not be empty.", name);
        }
    }

    /// <summary>
    /// Ensures that the collection must not contain null elements.
    /// </summary>
    /// <param name="collection">The collection to be tested.</param>
    /// <param name="name">The name of the tested collection.</param>
    /// <exception cref="ArgumentException">Thrown when the collection contains <see langword="null" /> elements.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ArgumentDoesNotContainNullElements<TType>(IEnumerable<TType> collection, [CallerArgumentExpression(nameof(collection))] string name = null)
    {
        if (collection.Any(item => item is null))
        {
            throw new ArgumentException("Collection contains null elements.", name);
        }
    }

    /// <summary>
    /// Ensures that the collection must not contain duplicate elements.
    /// </summary>
    /// <param name="collection">The collection to be tested.</param>
    /// <param name="name">The name of the tested collection.</param>
    /// <exception cref="ArgumentException">Thrown when the collection contains duplicate elements.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ArgumentDoesNotContainDuplicateElements<TType>(IEnumerable<TType> collection, [CallerArgumentExpression(nameof(collection))] string name = null)
    {
        var items = new HashSet<TType>();
        foreach (var item in collection)
        {
            if (!items.Add(item))
            {
                throw new ArgumentException("Collection contains duplicate elements.", name);
            }
        }
    }
}
