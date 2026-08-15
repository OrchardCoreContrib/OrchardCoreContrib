using System.Runtime.CompilerServices;

namespace OrchardCoreContrib.Infrastructure;

/// <summary>
/// Represents an argument checker.
/// </summary>
public static partial class Guard
{
    /// <summary>
    /// Ensures that the specified value is a valid enum value.
    /// </summary>
    /// <param name="value">The enum value to be tested.</param>
    /// <param name="paramName">The name of the tested parameter.</param>
    /// <exception cref="ArgumentException">Thrown if the value is not a valid enum value.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ArgumentIsDefined<TEnum>(TEnum value, string paramName) where TEnum : struct, Enum
    {
        if (!Enum.IsDefined(value))
        {
            throw new ArgumentOutOfRangeException(paramName, value, $"Value '{value}' is not a valid member of {typeof(TEnum).Name}.");
        }
    }

    /// <summary>
    /// Ensures that the specified value is not the default value of the enum type.
    /// </summary>
    /// <typeparam name="TEnum">The type of the enum.</typeparam>
    /// <param name="value">The enum value to be tested.</param>
    /// <param name="paramName">The name of the tested parameter.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the value is the default value of the enum type.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ArgumentNotDefault<TEnum>(TEnum value, string paramName) where TEnum : struct, Enum
    {
        if (EqualityComparer<TEnum>.Default.Equals(value, default))
        {
            throw new ArgumentOutOfRangeException(paramName, value, $"Value cannot be the default ({default(TEnum)}) for {typeof(TEnum).Name}.");
        }
    }
}
