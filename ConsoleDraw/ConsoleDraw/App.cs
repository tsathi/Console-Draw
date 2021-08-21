using System;
using System.Collections.Generic;
using ConsoleDraw.Interfaces;

namespace ConsoleDraw
{
    public class App
    {
        public void Init(IConsoleWriter consoleWriter, IConsoleReader consoleReader, IEnumerable<ICommand> commands, ICommandHandler commandHandler)
        {
            var userCommand = string.Empty;

            while (userCommand.ToLower() != "q")
            {
                userCommand = consoleReader.Read("Please enter your command: ");

                try
                {
                    commandHandler.ExecuteCommand(consoleWriter, commands, userCommand.Trim());
                }
                catch (InvalidOperationException e)
                {
                    consoleWriter.Write(e.Message);
                }
                catch (ArgumentException e)
                {
                    consoleWriter.Write(e.Message);
                }
                catch (Exception e)
                {
                    consoleWriter.Write("An internal error occurred. Please try again. If the error persists, please contact the dev team");
                    //Log.Error
                }
            }
        }
    }
}
