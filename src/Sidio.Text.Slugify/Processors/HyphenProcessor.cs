using System.Text.RegularExpressions;

namespace Sidio.Text.Slugify.Processors;

/// <summary>
/// The processor that replaces spaces with hyphens.
/// </summary>
// ReSharper disable once PartialTypeWithSinglePart
public partial class HyphenProcessor : SlugifyProcessor
{
    private const string Hyphen = "-";

#if !NET7_0_OR_GREATER
    private static readonly Regex HyphensRegex = new ("\\s", RegexOptions.Compiled);
#endif

    /// <inheritdoc />
    protected override string ProcessInput(string input)
    {
#if NET7_0_OR_GREATER
        return HypensRegex().Replace(input, Hyphen);
#else
        return HyphensRegex.Replace(input, Hyphen);
#endif
    }

    /// <inheritdoc />
    public override int Order => DefaultProcessorOrder.HyphenProcessor;

#if NET7_0_OR_GREATER
    [GeneratedRegex("\\s")]
    private static partial Regex HypensRegex();
#endif
}