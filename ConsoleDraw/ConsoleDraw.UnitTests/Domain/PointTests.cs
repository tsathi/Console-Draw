using System;
using ConsoleDraw.Domain;
using FluentAssertions;
using Xunit;

namespace ConsoleDraw.UnitTests.Domain
{
    public class PointTests
    {
        [Theory]
        [InlineData(-1, 1)]
        [InlineData(1, -1)]
        public void Should_throw_exception_when_coordinates_are_invalid(int x, int y)
        {
            Assert.Throws<ArgumentException>(() => new Point(x,y));
        }

        [Fact]
        public void Should_construct_object_when_coordinates_are_valid()
        {
            new Point(10, 20).Should().BeOfType<Point>();
        }
    }
}
