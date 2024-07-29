namespace Sidio.Text.Slugify.Extensions;

/// <summary>
/// The string extensions.
/// </summary>
public static class StringExtensions
{
    /// <summary>
    /// Returns a slugified version of the input string.
    /// </summary>
    /// <remarks>This function creates a new instance of a <see cref="Slugifier"/> every time it is called. It is
    /// recommended to use dependency injection.</remarks>
    /// <param name="input">The input.</param>
    /// <returns>A <see cref="string"/>.</returns>
#if NET7_0_OR_GREATER
    [return: System.Diagnostics.CodeAnalysis.NotNullIfNotNull(nameof(input))]
#endif
    public static string? Slugify(this string? input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        var slugifier = Slugifier.Create();
        return slugifier.Slugify(input);
    }
}