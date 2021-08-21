using System;
using System.Linq;
using ConsoleDraw.Commands;
using ConsoleDraw.Helpers;
using FluentValidation;

namespace ConsoleDraw.Validators
{
    public class UserCommandValidator : AbstractValidator<UserCommand>
    {
        public UserCommandValidator()
        {
            CascadeMode = CascadeMode.Stop;

            RuleSet("CanvasCommandValidationSet",
                () =>
                {
                    RuleFor(x => x.Command)
                        .Must(c => char.ToLower(c.First()) == 'c')
                            .WithErrorCode(Constants.PRE_CONDITION_ERROR_CODE)
                        .Must(c => c.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length == 3)
                            .WithMessage(Constants.INVALID_NUMER_OF_ARGUMENTS)
                        .Must(BeInts)
                            .WithMessage(Constants.INVALID_ARGUMENTS);
                });

            RuleSet("LineCommandValidationSet",
               () =>
               {
                   RuleFor(x => x.Command)
                          .Must(c => char.ToLower(c.First()) == 'l')
                               .WithErrorCode(Constants.PRE_CONDITION_ERROR_CODE)
                          .Must(c => c.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length == 5)
                              .WithMessage(Constants.INVALID_NUMER_OF_ARGUMENTS)
                          .Must(BeInts)
                              .WithMessage(Constants.INVALID_ARGUMENTS);
               });

            RuleSet("RectangleCommandValidationSet",
               () =>
               {
                   RuleFor(x => x.Command)
                          .Must(c => char.ToLower(c.First()) == 'r')
                              .WithErrorCode(Constants.PRE_CONDITION_ERROR_CODE)
                          .Must(c => c.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length == 5)
                              .WithMessage(Constants.INVALID_NUMER_OF_ARGUMENTS)
                          .Must(BeInts)
                              .WithMessage(Constants.INVALID_ARGUMENTS);
               });

            RuleSet("BucketFillCommandValidationSet",
               () =>
               {
                   RuleFor(x => x.Command)
                          .Must(c => char.ToLower(c.First()) == 'b')
                              .WithErrorCode(Constants.PRE_CONDITION_ERROR_CODE)
                          .Must(c => c.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length == 4)
                              .WithMessage(Constants.INVALID_NUMER_OF_ARGUMENTS)
                          .Must(HaveCharAsLastParameter)
                              .WithMessage(Constants.INVALID_ARGUMENTS);
               });
        }

        private bool BeInts(string cmd)
        {
            foreach (var param in cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries).Skip(1))
            {
                if (!int.TryParse(param, out _))
                    return false;
            }

            return true;
        }

        private bool HaveCharAsLastParameter(string cmd)
        {
            var args = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (var param in args.Skip(1).SkipLast(1))
            {
                if (!int.TryParse(param, out _))
                    return false;
            }

            return args.Last().Length == 1 && char.TryParse(args.Last(), out _);
        }
    }
}

