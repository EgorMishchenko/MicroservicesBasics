using Customer.Api.Contracts;
using Customer.Api.Utilities;
using FluentValidation;

namespace Customer.Api.Validators.v1
{
    public class CreateCustomerRequestValidator : AbstractValidator<CreateCustomerRequest>
    {
        public const int MaxBirthInterval = 123;

        public CreateCustomerRequestValidator(IDateTimeProvider dateTimeProvider)
        {
            var currentDate = dateTimeProvider.GetCurrentDate();

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
                .InclusiveBetween(currentDate.AddYears(-MaxBirthInterval), currentDate)
                .WithMessage("The birthday must not be longer ago than 150 years and can not be in the future");
        }
    }
}
