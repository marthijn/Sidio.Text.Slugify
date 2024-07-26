using System.Text.RegularExpressions;

namespace Sidio.Text.Slugify.Processors;

/// <summary>
/// The processor that removes special characters.
/// </summary>
// ReSharper disable once PartialTypeWithSinglePart
public partial class RemoveSpecialCharactersProcessor : SlugifyProcessor
{
#if !NET7_0_OR_GREATER
    private static readonly Regex InvalidCharacterRegex = new ("[^a-zA-Z0-9\\s-]", RegexOptions.Compiled);
#endif

    /// <inheritdoc />
    protected override string ProcessInput(string input)
    {
#if NET7_0_OR_GREATER
        return InvalidCharacterRegex().Replace(input, string.Empty);
#else
        return InvalidCharacterRegex.Replace(input, string.Empty);
#endif
    }

    /// <inheritdoc />
    public override int Order => DefaultProcessorOrder.RemoveSpecialCharactersProcessor;

#if NET7_0_OR_GREATER
    [GeneratedRegex("[^a-zA-Z0-9\\s-]")]
    private static partial Regex InvalidCharacterRegex();
#endif
}