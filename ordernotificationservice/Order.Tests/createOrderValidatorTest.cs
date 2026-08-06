using FluentValidation.TestHelper;
using Order.Application.Commands;
using Order.Application.Validators;

namespace Order.Tests.Validators;

public class CreateOrderValidatorTests
{
    private readonly CreateOrderValidator _validator = new();

    [Fact]
    public void Error_When_CustomerName_Is_Empty()
    {
        var command = new CreateOrderCommand(
            "",
            "Laptop",
            50000);

        var result = _validator.TestValidate(command);

        result.ShouldHaveValidationErrorFor(x => x.CustomerName);
    }

    [Fact]
    public void No_Validation_Error_For_Valid_Command()
    {
        var command = new CreateOrderCommand(
            "Soumya",
            "Laptop",
            50000);

        var result = _validator.TestValidate(command);

        result.ShouldNotHaveAnyValidationErrors();
    }
}