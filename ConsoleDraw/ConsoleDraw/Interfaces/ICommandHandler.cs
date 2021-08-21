using System.Collections.Generic;

namespace ConsoleDraw.Interfaces
{
    public interface ICommandHandler
    {
        void ExecuteCommand(IConsoleWriter consoleWriter, IEnumerable<ICommand> commands, string userCommand);
    }
}
