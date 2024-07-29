namespace Sidio.Text.Slugify.Processors;

/// <summary>
/// Replaces the ampersand character with the provided replacement character, e.g. "and".
/// </summary>
public sealed class AmpersandProcessor : SlugifyProcessor
{
    internal const string DefaultReplaceWith = " and ";

    private readonly string? _replaceWith;

    /// <summary>
    /// Creates a new instance of the <see cref="AmpersandProcessor"/> class.
    /// </summary>
    /// <param name="replaceWith">The string to replace the ampersand with.</param>
    public AmpersandProcessor(string? replaceWith)
    {
        _replaceWith = replaceWith;
    }

    /// <summary>
    /// Creates a new instance of the <see cref="AmpersandProcessor"/> class with the default settings.
    /// </summary>
    public AmpersandProcessor()
        : this(DefaultReplaceWith)
    {
    }

    /// <inheritdoc />
    protected override string ProcessInput(string input)
    {
        if (_replaceWith is null)
        {
            return input;
        }

        return input.Replace("&", _replaceWith);
    }

    /// <inheritdoc />
    public override int Order => DefaultProcessorOrder.AmpersandProcessor;
}