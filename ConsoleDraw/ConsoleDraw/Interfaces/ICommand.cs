using ConsoleDraw.Commands;
using FluentValidation.Results;

namespace ConsoleDraw.Interfaces
{
    public interface ICommand
    {
        ValidationResult CanExecute(UserCommand cmd);
        void Execute(UserCommand cmd);
    }

}
