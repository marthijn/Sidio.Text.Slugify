using Sidio.Text.Slugify.Processors;

namespace Sidio.Text.Slugify.Tests.Processors;

public sealed class EszettProcessorTests : SlugifyProcessorTestBase<EszettProcessor>
{
    [Fact]
    public void Process_WithInput_ReturnsExpected()
    {
        // act
        var actual = Processor.Process("abßcb");

        // assert
        actual.Should().Be("absscb");
    }
}