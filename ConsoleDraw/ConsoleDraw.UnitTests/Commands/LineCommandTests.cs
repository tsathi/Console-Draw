using System;
using ConsoleDraw.Commands;
using ConsoleDraw.Domain;
using ConsoleDraw.Interfaces;
using Moq;
using Xunit;

namespace ConsoleDraw.UnitTests.Commands
{
    public class LineCommandTests
    {
        [Fact]
        public void Should_throw_Exception_when_canvas_is_null()
        {
            var canvasMock = new Mock<ICanvas>();
            var cmd = new LineCommand(canvasMock.Object, null, null);
            Assert.Throws<InvalidOperationException>(() => cmd.Execute(new UserCommand { Command = "l 20 20 20 20" }));
        }

        [Fact]
        public void Should_draw_line()
        {
            var canvasMock = new Mock<ICanvas>();
            canvasMock.Setup(x => x.IsInitialized()).Returns(true);

            var lineDrawerMock = new Mock<ILineDrawerHandler>();
        
            var cmd = new LineCommand(canvasMock.Object, lineDrawerMock.Object, null);

            cmd.Execute(new UserCommand { Command = "l 20 20 20 20" });

            lineDrawerMock.Verify(x => x.Draw(canvasMock.Object,It.IsAny<Point>(), It.IsAny<Point>()));
            canvasMock.Verify(x => x.Display());
        }
    }
}
