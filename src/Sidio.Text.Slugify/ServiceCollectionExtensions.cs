using Microsoft.Extensions.DependencyInjection;

namespace Sidio.Text.Slugify;

/// <summary>
/// The service collection extensions.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds the slugifier service with the default configuration.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The <see cref="IServiceCollection"/>.</returns>
    public static IServiceCollection AddSlugifier(this IServiceCollection services) => services.AddSlugifier(_ => { });

    /// <summary>
    /// Adds the slugifier service with the specified configuration.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="options">The options.</param>
    /// <returns>The <see cref="IServiceCollection"/>.</returns>
    public static IServiceCollection AddSlugifier(this IServiceCollection services, Action<SlugifyConfig> options)
    {
        services.Configure(options);
        services.AddSingleton<ISlugifier, Slugifier>();
        return services;
    }
}