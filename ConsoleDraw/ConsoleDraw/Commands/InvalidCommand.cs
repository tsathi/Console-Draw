using System;
using ConsoleDraw.Interfaces;
using FluentValidation.Results;

namespace ConsoleDraw.Commands
{
    public class InvalidCommand : ICommand
    {
        public ValidationResult CanExecute(UserCommand cmd) => new ValidationResult(new[] { new ValidationFailure("Command", "Invalid command") });

        public void Execute(UserCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
