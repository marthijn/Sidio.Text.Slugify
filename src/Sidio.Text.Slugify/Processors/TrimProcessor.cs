namespace Sidio.Text.Slugify.Processors;

/// <summary>
/// Trims the input.
/// </summary>
public sealed class TrimProcessor : SlugifyProcessor
{
    /// <inheritdoc />
    protected override string ProcessInput(string input)
    {
        return input.Trim();
    }

    /// <inheritdoc />
    public override int Order => DefaultProcessorOrder.TrimProcessor;
}