using Sidio.Text.Slugify.Processors;

namespace Sidio.Text.Slugify.Tests.Processors;

public sealed class LigatureProcessorTests : SlugifyProcessorTestBase<LigatureProcessor>
{
    [Theory]
    [InlineData("abßcb", "absscb")]
    [InlineData("æÆœŒﬆ", "aeAEoeOEst")]
    [InlineData("aﬀaﬃaﬄaﬂaﬁaﬀ", "affaffiafflaflafiaff")]
    [InlineData("Øø", "Oo")]
    public void Process_WithInput_ReturnsExpected(string input, string expected)
    {
        // act
        var actual = Processor.Process(input);

        // assert
        actual.Should().Be(expected);
    }
}