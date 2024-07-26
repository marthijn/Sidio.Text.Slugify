using Sidio.Text.Slugify.Processors;

namespace Sidio.Text.Slugify.Tests.Processors;

public sealed class AmpersandProcessorTests : SlugifyProcessorTestBase<AmpersandProcessor>
{
    [Fact]
    public void Process_WithInput_ReturnsExpected()
    {
        // act
        var actual = Processor.Process("ab&cb");

        // assert
        actual.Should().Be("ab and cb");
    }
}