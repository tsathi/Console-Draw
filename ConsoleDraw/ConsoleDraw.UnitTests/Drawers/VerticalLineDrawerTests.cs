using ConsoleDraw.Domain;
using ConsoleDraw.Drawers;
using ConsoleDraw.Interfaces;
using Moq;
using Xunit;

namespace ConsoleDraw.UnitTests.Drawers
{
    public class VerticalLineDrawerTests
    {
        [Fact]
        public void Should_draw_line()
        {
            var canvasMock = new Mock<ICanvas>();
            var drawer = new VerticalLineDrawer();

            drawer.Draw(canvasMock.Object, new Point(0, 0), new Point(0, 4));
            canvasMock.Verify(x => x.DrawAt(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<char>()), Times.Exactly(5));
        }
    }
}
