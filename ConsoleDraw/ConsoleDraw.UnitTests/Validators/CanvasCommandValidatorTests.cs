using Xunit;

namespace ConsoleDraw.UnitTests.Validators
{
    public class CanvasCommandValidatorTests
    {
        [Fact]
        public void Should_have_no_error_when_valid_agrs_passed()
        {
            Asserts.Valid_command("c 2 2", "CanvasCommandValidationSet");
        }

        [Fact]
        public void Should_have_error_code_set_when_diffent_command_passed()
        {
            Asserts.Invalid_command("l 2 2", "CanvasCommandValidationSet");
        }

        [Fact]
        public void Should_have_error_when_number_of_ags_less_than_3()
        {
            Asserts.Number_of_args("c 2", "CanvasCommandValidationSet");
        }

        [Fact]
        public void Should_have_error_when_non_numerical_agrs_passed()
        {
            Asserts.Non_numerical_params("c 2a 2", "CanvasCommandValidationSet");
        }

    }
}
