using System;
using ConsoleDraw.Domain;
using ConsoleDraw.Drawers;
using ConsoleDraw.Interfaces;
using ConsoleDraw.Validators;
using FluentValidation;
using FluentValidation.Results;

namespace ConsoleDraw.Commands
{
    public class RectangleCommand : ICommand
    {
        private readonly ICanvas _canvas;
        private readonly IRectangleDrawer _rectangleDraw;
        private readonly IValidator<UserCommand> _validator;
        private readonly ILineDrawerHandler _linedrawerHandler;

        public RectangleCommand(ICanvas canvas, IRectangleDrawer rectangleDraw, ILineDrawerHandler linedrawerHandler, IValidator<UserCommand> validator)
        {
            _canvas = canvas;
            _rectangleDraw = rectangleDraw;
            _validator = validator;
            _linedrawerHandler = linedrawerHandler;
        }

        public ValidationResult CanExecute(UserCommand cmd) => _validator.Validate(cmd, options => options.IncludeRuleSets("RectangleCommandValidationSet"));

        public void Execute(UserCommand cmd)
        {
            if (!_canvas.IsInitialized())
                throw new InvalidOperationException("No canvas available to draw");

            var args = cmd.Command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var y1 = int.Parse(args[1]);
            var x1 = int.Parse(args[2]);
            var y2 = int.Parse(args[3]);
            var x2 = int.Parse(args[4]);

            _rectangleDraw.Draw(_canvas, new Rectangle(y1, x1, y2, x2), _linedrawerHandler);

            _canvas.Display();
        }
    }

}
