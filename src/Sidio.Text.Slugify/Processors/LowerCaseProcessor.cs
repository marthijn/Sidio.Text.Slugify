namespace Sidio.Text.Slugify.Processors;

/// <summary>
/// The processor that converts the input to lower case.
/// </summary>
public sealed class LowerCaseProcessor : SlugifyProcessor
{
    /// <inheritdoc />
    protected override string ProcessInput(string input)
    {
        return input.ToLowerInvariant();
    }

    /// <inheritdoc />
    public override int Order => DefaultProcessorOrder.LowerCaseProcessor;
}