using System;
using ConsoleDraw.Commands;
using ConsoleDraw.Domain;
using ConsoleDraw.Interfaces;
using FluentValidation;
using Moq;
using Xunit;

namespace ConsoleDraw.UnitTests.Commands
{
    public class RectangleCommandTests
    {
        [Fact]
        public void Should_throw_Exception_when_canvas_is_null()
        {
            var canvasMock = new Mock<ICanvas>();
            var cmd = new RectangleCommand(canvasMock.Object, null, null,null);
            Assert.Throws<InvalidOperationException>(() => cmd.Execute(new UserCommand { Command = "r 20 20 20 20" }));
        }

        [Fact]
        public void Should_draw_rectangle()
        {
            var canvasMock = new Mock<ICanvas>();
            canvasMock.Setup(x => x.IsInitialized()).Returns(true);

            var cmdMock = new Mock<IValidator<UserCommand>>();
            var rectDrawerMock = new Mock<IRectangleDrawer>();
            var lineDrawerMock = new Mock<ILineDrawerHandler>();
            var cmd = new RectangleCommand(canvasMock.Object, rectDrawerMock.Object, lineDrawerMock.Object, cmdMock.Object);

            cmd.Execute(new UserCommand { Command = "r 20 20 20 20" });

            rectDrawerMock.Verify(x => x.Draw(canvasMock.Object, It.IsAny<Rectangle>(), lineDrawerMock.Object));
            canvasMock.Verify(x => x.Display());
        }
    }
}
