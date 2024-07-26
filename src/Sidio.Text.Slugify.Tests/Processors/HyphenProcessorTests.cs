using Sidio.Text.Slugify.Processors;

namespace Sidio.Text.Slugify.Tests.Processors;

public sealed class HyphenProcessorTests : SlugifyProcessorTestBase<HyphenProcessor>
{
    [Fact]
    public void Process_WithInput_ReturnsExpected()
    {
        // act
        var actual = Processor.Process("x x x");

        // assert
        actual.Should().Be("x-x-x");
    }
}