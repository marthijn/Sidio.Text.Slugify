namespace Sidio.Text.Slugify.Tests;

public sealed class SlugifierTests
{
    [Theory]
    [InlineData("Hello, World!", "hello-world")]
    [InlineData("a&b", "a-and-b")]
    [InlineData("!ab123@", "ab123")]
    [InlineData("ée æd", "ee-d")]
    public void Slugify_WithDefaultProcessors_ReturnsExpected(string input, string expected)
    {
        // arrange
        var slugifier = Slugifier.Create();

        // act
        var actual = slugifier.Slugify(input);

        // assert
        actual.Should().Be(expected);
    }
}