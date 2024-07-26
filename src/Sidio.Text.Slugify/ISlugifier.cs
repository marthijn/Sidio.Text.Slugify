namespace Sidio.Text.Slugify;

/// <summary>
/// The slugifier.
/// </summary>
public interface ISlugifier
{
    /// <summary>
    /// Creates a slug from the given text.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns>A <see cref="string"/>.</returns>
#if NET5_0_OR_GREATER
    [return: System.Diagnostics.CodeAnalysis.NotNullIfNotNull(nameof(text))]
#endif
    public string? Slugify(string? text);
}