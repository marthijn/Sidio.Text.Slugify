using System.Globalization;
using System.Text;

namespace Sidio.Text.Slugify.Processors;

/// <summary>
/// Strips the diacritics and returns the base characters.
/// </summary>
public sealed class ReplaceDiacriticsProcessor : SlugifyProcessor
{
    /// <inheritdoc />
    protected override string ProcessInput(string input)
    {
        var normalizedString = input.Normalize(NormalizationForm.FormD);
        var stringBuilder = new StringBuilder();

        foreach (var c in normalizedString)
        {
            var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
            if (unicodeCategory != UnicodeCategory.NonSpacingMark)
            {
                stringBuilder.Append(c);
            }
        }

        return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
    }

    /// <inheritdoc />
    public override int Order => DefaultProcessorOrder.RemoveDiacriticsProcessor;
}