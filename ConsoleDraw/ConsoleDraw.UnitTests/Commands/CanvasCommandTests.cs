using ConsoleDraw.Commands;
using ConsoleDraw.Interfaces;
using FluentValidation;
using Moq;
using Xunit;

namespace ConsoleDraw.UnitTests.Commands
{
    public class CanvasCommandTests
    {
        [Fact]
        public void Should_create_new_canvas()
        {
            var canvasMock = new Mock<ICanvas>();
            var cmdMock = new Mock<IValidator<UserCommand>>();
            var cmd = new CanvasCommand(canvasMock.Object, cmdMock.Object);

            cmd.Execute(new UserCommand { Command = "c 20 20" });

            canvasMock.Verify(x => x.CreateNew(It.IsAny<int>(), It.IsAny<int>()));
            canvasMock.Verify(x => x.Display());
        }
    }
}
