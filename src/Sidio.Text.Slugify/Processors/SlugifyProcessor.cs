namespace Sidio.Text.Slugify.Processors;

/// <summary>
/// The base class for slugify processors.
/// </summary>
public abstract class SlugifyProcessor
{
    /// <summary>
    /// Processes the input string.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <returns>A <see cref="string"/>.</returns>
#if NET7_0_OR_GREATER
    [return: System.Diagnostics.CodeAnalysis.NotNullIfNotNull(nameof(input))]
#endif
    public string? Process(string? input)
    {
        return input == null ? input : ProcessInput(input);
    }

    /// <summary>
    /// Processes the input string.
    /// </summary>
    /// <param name="input">The input.</param>
    /// <returns>A <see cref="string"/>.</returns>
    protected abstract string ProcessInput(string input);

    /// <summary>
    /// Gets the order of the processor.
    /// </summary>
    public virtual int Order => int.MaxValue / 2;
}