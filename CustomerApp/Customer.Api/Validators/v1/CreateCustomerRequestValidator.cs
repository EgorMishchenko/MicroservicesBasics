using Customer.Api.Contracts;
using FluentValidation;

namespace Customer.Api.Validators.v1
{
  public class CreateCustomerRequestValidator : AbstractValidator<CreateCustomerRequest>
  {
    public CreateCustomerRequestValidator()
    {
      RuleFor(x => x.FirstName)
        .NotNull()
        .WithMessage("The first name must be at least 2 character long");
      RuleFor(x => x.FirstName)
        .MinimumLength(2)
        .WithMessage("The first name must be at least 2 character long");

      RuleFor(x => x.LastName)
        .NotNull()
        .WithMessage("The last name must be at least 2 character long");
      RuleFor(x => x.LastName)
        .MinimumLength(2)
        .WithMessage("The last name must be at least 2 character long");

      RuleFor(x => x.Birthday)
        .InclusiveBetween(DateTime.Now.AddYears(-150).Date, DateTime.Now)
        .WithMessage("The birthday must not be longer ago than 150 years and can not be in the future");
    }
  }
}
