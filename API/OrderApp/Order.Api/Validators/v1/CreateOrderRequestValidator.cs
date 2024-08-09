using FluentValidation;
using Order.Api.Contracts;

namespace Order.Api.Validators.v1
{
  public class CreateOrderRequestValidator : AbstractValidator<CreateOrderRequest>
  {
    public CreateOrderRequestValidator()
    {
      RuleFor(x => x.CustomerFullName)
        .NotNull()
        .WithMessage("The customer name must be at least 2 character long");
      RuleFor(x => x.CustomerFullName)
        .MinimumLength(2).WithMessage("The customer name must be at least 2 character long");
    }
  }
}
