using Sidio.Text.Slugify.Processors;

namespace Sidio.Text.Slugify.Tests.Processors;

public abstract class SlugifyProcessorTestBase<TProcessor>
    where TProcessor : SlugifyProcessor, new()
{
    protected TProcessor Processor => new ();

    [Fact]
    public void Process_WithNullInput_ReturnsNull()
    {
        // act
        var actual = Processor.Process(null);

        // assert
        actual.Should().BeNull();
    }

    [Fact]
    public void Process_WithEmptyStringInput_ReturnsEmptyString()
    {
        // act
        var actual = Processor.Process(string.Empty);

        // assert
        actual.Should().Be(string.Empty);
    }
}