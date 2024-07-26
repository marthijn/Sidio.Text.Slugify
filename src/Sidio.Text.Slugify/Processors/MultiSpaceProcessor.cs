using System.Text.RegularExpressions;

namespace Sidio.Text.Slugify.Processors;

/// <summary>
/// The processor that replaces multiple spaces with a single space.
/// </summary>
// ReSharper disable once PartialTypeWithSinglePart
public partial class MultiSpaceProcessor : SlugifyProcessor
{
#if !NET7_0_OR_GREATER
    private static readonly Regex MultipleSpacesRegex = new ("\\s+", RegexOptions.Compiled);
#endif

    /// <inheritdoc />
    protected override string ProcessInput(string input)
    {
#if NET7_0_OR_GREATER
        return MultipleSpacesRegex().Replace(input, " ");
#else
        return MultipleSpacesRegex.Replace(input, " ");
#endif
    }

    /// <inheritdoc />
    public override int Order => DefaultProcessorOrder.MultiSpaceProcessor;

#if NET7_0_OR_GREATER
    [GeneratedRegex("\\s+")]
    private static partial Regex MultipleSpacesRegex();
#endif
}