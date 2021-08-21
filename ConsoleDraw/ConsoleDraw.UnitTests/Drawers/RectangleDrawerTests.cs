using ConsoleDraw.Domain;
using ConsoleDraw.Drawers;
using ConsoleDraw.Interfaces;
using Moq;
using Xunit;

namespace ConsoleDraw.UnitTests.Drawers
{
    public class RectangleDrawerTests
    {
        [Fact]
        public void Should_draw_rectangle()
        {
            var canvasMock = new Mock<ICanvas>();
            var ldMock = new Mock<ILineDrawerHandler>();
            var drawer = new RectangleDrawer();
            
            drawer.Draw(canvasMock.Object, new Rectangle(0, 0, 5, 5), ldMock.Object);
            ldMock.Verify(x => x.Draw(It.IsAny<ICanvas>(), It.IsAny<Point>(), It.IsAny<Point>()), Times.Exactly(4));
        }
    }
}
