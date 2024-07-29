using Sidio.Text.Slugify.Processors;

namespace Sidio.Text.Slugify;

/// <summary>
/// The configuration for the slugify service.
/// </summary>
public sealed class SlugifyConfig
{
    /// <summary>
    /// Gets or sets a value indicating whether to add default processors.
    /// </summary>
    public bool AddDefaultProcessors { get; set; } = true;

    /// <summary>
    /// Gets the processors.
    /// </summary>
    public List<SlugifyProcessor> Processors { get; } = new ();

    /// <summary>
    /// Gets or sets the characters to replace ampersands with.
    /// When the value is set to null, the <see cref="AmpersandProcessor"/> is not added to the list of processors.
    /// It is recommended to add a space before and after the replacement string to avoid concatenation.
    /// of processors.
    /// </summary>
    public string? ReplaceAmpersandWith { get; set; } = AmpersandProcessor.DefaultReplaceWith;
}