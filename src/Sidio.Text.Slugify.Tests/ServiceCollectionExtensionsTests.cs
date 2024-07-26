using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Sidio.Text.Slugify.Processors;

namespace Sidio.Text.Slugify.Tests;

public sealed class ServiceCollectionExtensionsTests
{
    [Fact]
    public void AddSlugifier_AddsSlugifierService()
    {
        // arrange
        var services = new ServiceCollection();

        // act
        services.AddSlugifier();

        // assert
        var serviceDescriptor = services.FirstOrDefault(descriptor => descriptor.ServiceType == typeof(ISlugifier));
        serviceDescriptor.Should().NotBeNull();
        serviceDescriptor!.Lifetime.Should().Be(ServiceLifetime.Singleton);
        serviceDescriptor.ImplementationType.Should().Be(typeof(Slugifier));

        var configureOptionsDescriptor = services.FirstOrDefault(descriptor => descriptor.ServiceType == typeof(IConfigureOptions<SlugifyConfig>));
        configureOptionsDescriptor.Should().NotBeNull();
        configureOptionsDescriptor!.Lifetime.Should().Be(ServiceLifetime.Singleton);
    }

    [Fact]
    public void AddSlugifier_WithOptions_AddsSlugifierService()
    {
        // arrange
        var services = new ServiceCollection();

        // act
        services.AddSlugifier(
            options =>
            {
                options.AddDefaultProcessors = false;
                options.Processors.Add(new AmpersandProcessor());
            });

        // assert
        var serviceDescriptor = services.FirstOrDefault(descriptor => descriptor.ServiceType == typeof(ISlugifier));
        serviceDescriptor.Should().NotBeNull();
        serviceDescriptor!.Lifetime.Should().Be(ServiceLifetime.Singleton);
        serviceDescriptor.ImplementationType.Should().Be(typeof(Slugifier));

        var configureOptionsDescriptor = services.FirstOrDefault(descriptor => descriptor.ServiceType == typeof(IConfigureOptions<SlugifyConfig>));
        configureOptionsDescriptor.Should().NotBeNull();
        configureOptionsDescriptor!.Lifetime.Should().Be(ServiceLifetime.Singleton);
    }
}