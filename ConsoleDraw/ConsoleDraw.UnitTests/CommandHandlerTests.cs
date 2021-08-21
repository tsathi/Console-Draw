using System.Collections.Generic;
using ConsoleDraw.Commands;
using ConsoleDraw.Interfaces;
using Moq;
using Xunit;
using FluentValidation.Results;
using ConsoleDraw.Helpers;

namespace ConsoleDraw.UnitTests
{
    public class CommandHandlerTests
    {
        [Fact]
        public void Should_execute_command_when_matching_handler_found()
        {
            var writerMock = new Mock<IConsoleWriter>();
            var cmdHandler = new CommandHandler();
            var cmd = new Mock<ICommand>();
            cmd.Setup(x => x.CanExecute(It.IsAny<UserCommand>())).Returns(new ValidationResult());

            IEnumerable<ICommand> cmds = new List<ICommand> { cmd.Object };
            cmdHandler.ExecuteCommand(writerMock.Object, cmds, "c 20 4");
            cmd.Verify(x => x.Execute(It.IsAny<UserCommand>()));
        }

        [Fact]
        public void Should_write_to_console_when_conditions_failed()
        {
            var writerMock = new Mock<IConsoleWriter>();
            var cmdHandler = new CommandHandler();
            var cmd = new Mock<ICommand>();
            var vf = new ValidationFailure(string.Empty, string.Empty) { ErrorCode = Constants.INVALID_ARGUMENTS };
            cmd.Setup(x => x.CanExecute(It.IsAny<UserCommand>())).Returns(new ValidationResult(new List<ValidationFailure> { vf }));

            IEnumerable<ICommand> cmds = new List<ICommand> { cmd.Object };
            cmdHandler.ExecuteCommand(writerMock.Object, cmds, "c 20 4");
            writerMock.Verify(x => x.Write(string.Empty));
        }
    }
}
