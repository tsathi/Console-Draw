using System.Collections.Generic;
using System.Linq;
using ConsoleDraw.Commands;
using ConsoleDraw.Helpers;
using ConsoleDraw.Interfaces;

namespace ConsoleDraw
{
    public class CommandHandler : ICommandHandler
    {
        public void ExecuteCommand(IConsoleWriter consoleWriter, IEnumerable<ICommand> commands, string userCommand)
        {
            foreach (var command in commands)
            {
                var validationResult = command.CanExecute(new UserCommand { Command = userCommand });

                if (validationResult.IsValid)
                {
                    command.Execute(new UserCommand { Command = userCommand });
                    break;
                }
                else if (validationResult.Errors.Any(x => x.ErrorCode != Constants.PRE_CONDITION_ERROR_CODE))
                {
                    validationResult.Errors.ForEach(x => consoleWriter.Write(x.ErrorMessage));
                    break;
                }
            }
        }
    }
}
