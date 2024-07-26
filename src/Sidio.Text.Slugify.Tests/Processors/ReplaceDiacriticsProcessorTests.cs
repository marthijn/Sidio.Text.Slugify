using Sidio.Text.Slugify.Processors;

namespace Sidio.Text.Slugify.Tests.Processors;

public sealed class ReplaceDiacriticsProcessorTests : SlugifyProcessorTestBase<ReplaceDiacriticsProcessor>
{
    [Theory]
    [InlineData("ÀÁÂÃÄÅ", "AAAAAA")] // Æ Ð Ø  Þ ß æ ø  þ
    [InlineData("Ç", "C")]
    [InlineData("ÈÉÊË", "EEEE")]
    [InlineData("ÌÍÎÏ", "IIII")]
    [InlineData("Ñ", "N")]
    [InlineData("ÒÓÔÕÖ", "OOOOO")]
    [InlineData("ÙÚÛÜ", "UUUU")]
    [InlineData("Ý", "Y")]
    [InlineData("àáâãäå", "aaaaaa")]
    [InlineData("ç", "c")]
    [InlineData("èéêë", "eeee")]
    [InlineData("ìíîï", "iiii")]
    [InlineData("òóôõö", "ooooo")]
    [InlineData("ñ", "n")]
    [InlineData("ùúûü", "uuuu")]
    [InlineData("ýÿ", "yy")]
    public void Process_WithInput_ReturnsExpected(string input, string expected)
    {
        // act
        var actual = Processor.Process(input);

        // assert
        actual.Should().Be(expected);
    }
}