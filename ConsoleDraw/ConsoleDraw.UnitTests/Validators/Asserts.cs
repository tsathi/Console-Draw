using ConsoleDraw.Validators;
using FluentValidation.TestHelper;
using FluentValidation;
using ConsoleDraw.Commands;
using ConsoleDraw.Helpers;

namespace ConsoleDraw.UnitTests.Validators
{
    public static class Asserts
    {
        public static void Invalid_command(string cmd, string ruleSet)
        {
            var userCommandValidator = new UserCommandValidator();
            var result = userCommandValidator.TestValidate(new UserCommand { Command = cmd }, s => s.IncludeRuleSets(ruleSet));
            result.ShouldHaveValidationErrorFor(x => x.Command)
                .WithErrorCode(Constants.PRE_CONDITION_ERROR_CODE);
        }

        public static void Valid_command(string cmd, string ruleSet)
        {
            var userCommandValidator = new UserCommandValidator();
            var result = userCommandValidator.TestValidate(new UserCommand { Command = cmd }, s => s.IncludeRuleSets(ruleSet));
            result.ShouldNotHaveAnyValidationErrors();
        }

        public static void Number_of_args(string cmd, string ruleSet)
        {
            var userCommandValidator = new UserCommandValidator();
            var result = userCommandValidator.TestValidate(new UserCommand { Command = cmd }, s => s.IncludeRuleSets(ruleSet));
            result.ShouldHaveValidationErrorFor(x => x.Command)
                .WithErrorMessage(Constants.INVALID_NUMER_OF_ARGUMENTS);
        }

        public static void Non_numerical_params(string cmd, string ruleSet)
        {
            var userCommandValidator = new UserCommandValidator();
            var result = userCommandValidator.TestValidate(new UserCommand { Command = cmd, }, s => s.IncludeRuleSets(ruleSet));
            result.ShouldHaveValidationErrorFor(x => x.Command)
                .WithErrorMessage(Constants.INVALID_ARGUMENTS);
        }
    }
}
