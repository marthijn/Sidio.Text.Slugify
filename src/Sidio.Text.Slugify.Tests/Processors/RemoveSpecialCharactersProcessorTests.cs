using Sidio.Text.Slugify.Processors;

namespace Sidio.Text.Slugify.Tests.Processors;

public sealed class RemoveSpecialCharactersProcessorTests : SlugifyProcessorTestBase<RemoveSpecialCharactersProcessor>
{
    [Theory]
    [InlineData("ÆÐØÞßæøþ", "")]
    [InlineData("`~!@#$%^&*()-=_+[]{};:'\".,<>/?", "-")]
    [InlineData("0123456789", "0123456789")]
    [InlineData(
        "abcdefghijklmnopqrstuvwxyz ABCDEFGHIJKLMNOPQRSTUVWXYZ",
        "abcdefghijklmnopqrstuvwxyz ABCDEFGHIJKLMNOPQRSTUVWXYZ")]
    public void Process_WithInput_ReturnsExpected(string input, string expected)
    {
        // act
        var actual = Processor.Process(input);

        // assert
        actual.Should().Be(expected);
    }
}