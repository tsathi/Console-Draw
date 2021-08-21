using System;
using ConsoleDraw.Domain;
using FluentAssertions;
using Xunit;

namespace ConsoleDraw.UnitTests.Domain
{
    public class RectangleTests
    {
        [Theory]
        [InlineData(-1, 1, 1, 1)]
        [InlineData(1, -1, 1, 1)]
        [InlineData(1, 1, -1, 1)]
        [InlineData(1, 1, 1, -1)]
        public void Should_throw_exception_when_coordinates_are_invalid(int x1, int y1, int x2, int y2)
        {
            Assert.Throws<ArgumentException>(() => new Rectangle(x1, y1, x2, y2));
        }

        [Fact]
        public void Should_construct_object_when_coordinates_are_valid()
        {
            new Rectangle(10, 20,30,40).Should().BeOfType<Rectangle>();
        }
    }
}
