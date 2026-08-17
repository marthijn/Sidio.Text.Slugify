namespace Sidio.Text.Slugify.Processors;

/// <summary>
/// Replaces ligature characters with their corresponding ASCII representations.
/// For example, the German Eszett character "ß" is replaced with "ss".
/// </summary>
public sealed class LigatureProcessor : SlugifyProcessor
{
    /// <inheritdoc />
    protected override string ProcessInput(string input)
    {
        return input
            .Replace("æ", "ae")
            .Replace("Æ", "AE")
            .Replace("œ", "oe")
            .Replace("Œ", "OE")
            .Replace("ﬆ", "st")
            .Replace("ø", "o")
            .Replace("Ø", "O")
            .Replace("ﬀ", "ff")
            .Replace("ﬃ", "ffi")
            .Replace("ﬄ", "ffl")
            .Replace("ﬂ", "fl")
            .Replace("ﬁ", "fi")
            .Replace("ß", "ss");
    }

    /// <inheritdoc />
    public override int Order => DefaultProcessorOrder.LigatureProcessor;
}