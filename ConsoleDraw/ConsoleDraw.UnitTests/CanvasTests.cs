using System;
using FluentAssertions;
using Xunit;

namespace ConsoleDraw.UnitTests
{
    public class CanvasTests
    {
        [Fact]
        public void Should_return_false_when_internal_array_is_not_initialized()
        {
            var canvas = new Canvas(null);
            var isInitialized = canvas.IsInitialized();
            isInitialized.Should().BeFalse();
        }

        [Fact]
        public void Should_return_true_when_internal_array_is_initialized()
        {
            var canvas = new Canvas(null);
            canvas.CreateNew(10, 10);
            var isInitialized = canvas.IsInitialized();
            isInitialized.Should().BeTrue();
        }

        [Theory]
        [InlineData(5,5,true)]
        [InlineData(11,10, false)]
        [InlineData(10, 11, false)]
        [InlineData(11, 11, false)]
        public void Should_return_whether_point_is_inside_or_not(int col, int row, bool result)
        {
            var canvas = new Canvas(null);
            canvas.CreateNew(10, 10);
            var isInitialized = canvas.IsPointOnCanvas(col, row);
            isInitialized.Should().Be(result);
        }

        [Fact]
        public void Should_draw_at_point()
        {
            var canvas = new Canvas(null);
            canvas.CreateNew(10, 10);
            canvas.DrawAt(1, 1,'x');
            canvas.GetCanvas()[0, 0].Should().Be('x');
        }

        [Theory]
        [InlineData(0, 0, false)]
        [InlineData(1, 2, true)]
        public void Should_return_pixel_status(int col, int row, bool result)
        {
            var canvas = new Canvas(null);
            canvas.CreateNew(10, 10);
            canvas.GetCanvas()[0, 0] = 'x';
            var isEmpty = canvas.IsPixelEmpty(col, row);
            isEmpty.Should().Be(result);
        }
    }
}
