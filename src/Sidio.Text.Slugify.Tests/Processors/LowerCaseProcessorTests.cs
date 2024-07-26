using Sidio.Text.Slugify.Processors;

namespace Sidio.Text.Slugify.Tests.Processors;

public sealed class LowerCaseProcessorTests : SlugifyProcessorTestBase<LowerCaseProcessor>
{
    [Fact]
    public void Process_WithInput_ReturnsExpected()
    {
        // act
        var actual = Processor.Process("AbCdE");

        // assert
        actual.Should().Be("abcde");
    }
}