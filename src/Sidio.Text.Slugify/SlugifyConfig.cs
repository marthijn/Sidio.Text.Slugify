﻿using Sidio.Text.Slugify.Processors;

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
}