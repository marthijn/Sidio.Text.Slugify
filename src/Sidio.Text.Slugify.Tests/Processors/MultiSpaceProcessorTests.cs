using Sidio.Text.Slugify.Processors;

namespace Sidio.Text.Slugify.Tests.Processors;

public sealed class MultiSpaceProcessorTests : SlugifyProcessorTestBase<MultiSpaceProcessor>
{
    [Theory]
    [InlineData(" ", " ")]
    [InlineData("  ", " ")]
    [InlineData("   ", " ")]
    [InlineData("a b  c", "a b c")]
    public void Process_WithInput_ReturnsExpected(string input, string expected)
    {
        // act
        var actual = Processor.Process(input);

        // assert
        actual.Should().Be(expected);
    }
}