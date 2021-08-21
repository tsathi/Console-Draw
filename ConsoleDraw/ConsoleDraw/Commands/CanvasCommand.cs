using System;
using ConsoleDraw.Interfaces;
using FluentValidation;
using FluentValidation.Results;

namespace ConsoleDraw.Commands
{
    public class CanvasCommand : ICommand
    {
        private readonly ICanvas _canvas;
        private readonly IValidator<UserCommand> _validator;

        public CanvasCommand(ICanvas canvas, IValidator<UserCommand> validator)
        {
            _canvas = canvas;
            _validator = validator;
        }

        public ValidationResult CanExecute(UserCommand cmd) => _validator.Validate(cmd, options => options.IncludeRuleSets("CanvasCommandValidationSet"));

        public void Execute(UserCommand cmd)
        {
            var args = cmd.Command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var col = int.Parse(args[1]);
            var row = int.Parse(args[2]);

            _canvas.CreateNew(col,row);

            _canvas.Display();
        }
    }
}
