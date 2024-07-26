namespace Sidio.Text.Slugify.Processors;

/// <summary>
/// Replaces the German Eszett character with "ss".
/// </summary>
public sealed class EszettProcessor : SlugifyProcessor
{
    /// <inheritdoc />
    protected override string ProcessInput(string input)
    {
        return input.Replace("ß", "ss");
    }

    /// <inheritdoc />
    public override int Order => DefaultProcessorOrder.EszettProcessor;
}