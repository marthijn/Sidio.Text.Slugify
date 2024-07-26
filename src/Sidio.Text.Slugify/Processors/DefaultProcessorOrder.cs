namespace Sidio.Text.Slugify.Processors;

internal static class DefaultProcessorOrder
{
    private const int DefaultVariation = 1000;

    // pre-processors
    public const int AmpersandProcessor = DefaultVariation;
    public const int EszettProcessor = AmpersandProcessor + DefaultVariation;
    public const int RemoveDiacriticsProcessor = EszettProcessor + DefaultVariation;
    public const int RemoveSpecialCharactersProcessor = RemoveDiacriticsProcessor + DefaultVariation;

    // processors
    public const int MultiSpaceProcessor = LowerCaseProcessor - DefaultVariation;
    public const int LowerCaseProcessor = TrimProcessor - DefaultVariation;
    public const int TrimProcessor = HyphenProcessor - DefaultVariation;
    public const int HyphenProcessor = int.MaxValue - DefaultVariation;
}