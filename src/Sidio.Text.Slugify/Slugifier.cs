using Microsoft.Extensions.Options;
using Sidio.Text.Slugify.Processors;

namespace Sidio.Text.Slugify;

/// <summary>
/// The slugifier.
/// </summary>
public sealed class Slugifier : ISlugifier
{
    private static SlugifyProcessor[] DefaultProcessors => new SlugifyProcessor[]
    {
        new EszettProcessor(),
        new HyphenProcessor(),
        new MultiSpaceProcessor(),
        new LowerCaseProcessor(),
        new ReplaceDiacriticsProcessor(),
        new RemoveSpecialCharactersProcessor()
    };

    private readonly IReadOnlyList<SlugifyProcessor> _processors;

    /// <summary>
    /// Initializes a new instance of the <see cref="Slugifier"/> class.
    /// </summary>
    /// <param name="options">The options.</param>
    public Slugifier(IOptions<SlugifyConfig> options)
        : this(
            options.Value.AddDefaultProcessors,
            options.Value.Processors,
            options.Value.ReplaceAmpersandWith)
    {
    }

    private Slugifier(
        bool addDefaultProcessors,
        IEnumerable<SlugifyProcessor>? processors = null,
        string? replaceAmpersandWith = AmpersandProcessor.DefaultReplaceWith)
    {
        var processorList = new List<SlugifyProcessor>();
        if (addDefaultProcessors)
        {
            processorList.AddRange(DefaultProcessors);
        }

        if (processors != null)
        {
            processorList.AddRange(processors);
        }

        if (replaceAmpersandWith != null)
        {
            processorList.Add(new AmpersandProcessor(replaceAmpersandWith));
        }

        processorList.Sort((x, y) => x.Order.CompareTo(y.Order));
        _processors = processorList;
    }

    /// <summary>
    /// Creates a new instance of a <see cref="Slugifier"/>.
    /// </summary>
    /// <param name="addDefaultProcessors">A value indicating whether to add the default processors.</param>
    /// <param name="processors">The processors.</param>
    /// <returns>The <see cref="Slugifier"/>.</returns>
    public static Slugifier Create(
        bool addDefaultProcessors = true,
        IEnumerable<SlugifyProcessor>? processors = null) => new Slugifier(addDefaultProcessors, processors);

    /// <summary>
    /// Returns a slugified (i.e. URL friendly) version of the text.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns>A <see cref="string"/>.</returns>
#if NET7_0_OR_GREATER
    [return: System.Diagnostics.CodeAnalysis.NotNullIfNotNull(nameof(text))]
#endif
    public string? Slugify(string? text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return text;
        }

        return _processors.Aggregate(text, (current, processor) => processor.Process(current));
    }
}