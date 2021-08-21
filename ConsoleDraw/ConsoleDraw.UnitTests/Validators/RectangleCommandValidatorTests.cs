using System;
using Xunit;

namespace ConsoleDraw.UnitTests.Validators
{
    public class RectangleCommandValidatorTests
    {
        [Fact]
        public void Should_have_no_error_when_valid_agrs_passed()
        {
            Asserts.Valid_command("r 2 2 2 2", "RectangleCommandValidationSet");
        }

        [Fact]
        public void Should_have_error_code_set_when_diffent_command_passed()
        {
            Asserts.Invalid_command("c 2 2", "RectangleCommandValidationSet");
        }

        [Fact]
        public void Should_have_error_when_number_of_ags_is_not_5()
        {
            Asserts.Number_of_args("r 2 3", "RectangleCommandValidationSet");
        }

        [Fact]
        public void Should_have_error_when_non_numerical_agrs_passed()
        {
            Asserts.Non_numerical_params("r 2a 2 3 3b", "RectangleCommandValidationSet");
        }
    }
}
