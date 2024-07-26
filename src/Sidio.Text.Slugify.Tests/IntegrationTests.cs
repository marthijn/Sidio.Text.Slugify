using Microsoft.Extensions.DependencyInjection;
using Sidio.Text.Slugify.Processors;

namespace Sidio.Text.Slugify.Tests;

public sealed class IntegrationTests
{
    [Fact]
    public void IntegrationTest_WithDefaultConfiguration_ShouldReplaceAmpersands()
    {
        // arrange
        var services = new ServiceCollection();
        services.AddSlugifier();

        var serviceProvider = services.BuildServiceProvider();

        // act
        var sluggifier = serviceProvider.GetRequiredService<ISlugifier>();
        var result = sluggifier.Slugify("Hello, world! & Goodbye, world!");

        // assert
        result.Should().Be("hello-world-and-goodbye-world");
    }

    [Fact]
    public void IntegrationTest_WithLowerCaseProcessorOnly_ShouldReplaceCapitals()
    {
        // arrange
        var services = new ServiceCollection();
        services.AddSlugifier(
            x =>
            {
                x.AddDefaultProcessors = false;
                x.Processors.Add(new LowerCaseProcessor());
            });

        var serviceProvider = services.BuildServiceProvider();

        // act
        var sluggifier = serviceProvider.GetRequiredService<ISlugifier>();
        var result = sluggifier.Slugify("Hello, world! & Goodbye, world!");

        // assert
        result.Should().Be("hello, world! & goodbye, world!");
    }
}