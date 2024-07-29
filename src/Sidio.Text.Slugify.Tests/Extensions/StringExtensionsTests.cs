using Sidio.Text.Slugify.Extensions;

namespace Sidio.Text.Slugify.Tests.Extensions;

public sealed class StringExtensionsTests
{
    [Fact]
    public void Slugify_WithInput_ReturnsSlug()
    {
        // arrange
        var input = "abc d";

        // act
        var actual = input.Slugify();

        // assert
        actual.Should().Be("abc-d");
    }

    [Fact]
    public void Slugify_WithEmptyInput_ReturnsEmptyString()
    {
        // act
        var actual = string.Empty.Slugify();

        // assert
        actual.Should().BeEmpty();
    }
}