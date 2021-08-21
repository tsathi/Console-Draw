using System;
using ConsoleDraw.Interfaces;
using FluentValidation;
using FluentValidation.Results;

namespace ConsoleDraw.Commands
{
    public class BucketFillCommand : ICommand
    {
        private readonly ICanvas _canvas;
        private readonly IValidator<UserCommand> _validator;

        public BucketFillCommand(ICanvas canvas, IValidator<UserCommand> validator)
        {
            _canvas = canvas;
            _validator = validator;
        }

        public ValidationResult CanExecute(UserCommand cmd) => _validator.Validate(cmd, options => options.IncludeRuleSets("BucketFillCommandValidationSet"));

        public void Execute(UserCommand cmd)
        {
            if (!_canvas.IsInitialized())
                throw new InvalidOperationException("No canvas available to draw");

            var args = cmd.Command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var col = int.Parse(args[1]) - 1;
            var row = int.Parse(args[2]) - 1;
            var color = char.Parse(args[3]);

            BucketFill(col, row, color);

            _canvas.Display();
        }

        private void BucketFill(int y, int x, char ch)
        {
            if (!_canvas.IsPointOnCanvas(y, x))
                return;

            if (!_canvas.IsPixelEmpty(y, x))
                return;

            _canvas.DrawAt(y, x, ch);

            BucketFill(y, x + 1, ch);
            BucketFill(y, x - 1, ch);
            BucketFill(y - 1, x, ch);
            BucketFill(y + 1, x, ch);
        }
    }
}
