using System;
using ConsoleDraw.Domain;
using ConsoleDraw.Drawers;
using ConsoleDraw.Interfaces;
using FluentValidation;
using FluentValidation.Results;

namespace ConsoleDraw.Commands
{
    public class LineCommand : ICommand
    {
        private readonly ICanvas _canvas;
        private readonly ILineDrawerHandler _lineDrawerHandler;
        private readonly IValidator<UserCommand> _validator;

        public LineCommand(ICanvas canvas, ILineDrawerHandler lineDrawerHandler, IValidator<UserCommand> validator)
        {
            _canvas = canvas;
            _lineDrawerHandler = lineDrawerHandler;
            _validator = validator;
        }

        public ValidationResult CanExecute(UserCommand cmd) => _validator.Validate(cmd, options => options.IncludeRuleSets("LineCommandValidationSet"));

        public void Execute(UserCommand cmd)
        {
            if (!_canvas.IsInitialized())
                throw new InvalidOperationException("No canvas available to draw");

            var args = cmd.Command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var y1 = int.Parse(args[1]);
            var x1 = int.Parse(args[2]);
            var y2 = int.Parse(args[3]);
            var x2 = int.Parse(args[4]);

            _lineDrawerHandler.Draw(_canvas, new Point(y1, x1), new Point(y2, x2));

            _canvas.Display();
        }
    }

}
