namespace Sidio.Text.Slugify.Processors;

/// <summary>
/// Replaces the ampersand character with the word "and", with a prefix and suffix empty character.
/// Use the <see cref="MultiSpaceProcessor"/> to remove the empty characters.
/// </summary>
public sealed class AmpersandProcessor : SlugifyProcessor
{
    /// <inheritdoc />
    protected override string ProcessInput(string input)
    {
        return input.Replace("&", " and ");
    }

    /// <inheritdoc />
    public override int Order => DefaultProcessorOrder.AmpersandProcessor;
}