using Sidio.Text.Slugify.Processors;

namespace Sidio.Text.Slugify.Tests.Processors;

public sealed class TrimProcessorTests : SlugifyProcessorTestBase<TrimProcessor>
{
    [Fact]
    public void Process_WithInput_ReturnsExpected()
    {
        // act
        var actual = Processor.Process(" abc d ");

        // assert
        actual.Should().Be("abc d");
    }
}